using AutoBogus.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Binder = Bogus.Binder;

namespace AutoBogus
{
  /// <summary>
  /// A class for binding generated instances.
  /// </summary>
  public class AutoBinder
    : Binder, IAutoBinder
  {
    /// <summary>
    /// Creates an instance of <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to create.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance for the generate request.</param>
    /// <returns>The created instance of <typeparamref name="TType"/>.</returns>
    public virtual TType CreateInstance<TType>(AutoGenerateContext context)
    {
      if (context != null)
      {
        var type = typeof(TType);
        var constructor = GetConstructor<TType>();

        if (constructor != null)
        {
          // If a constructor is found generate values for each of the parameters
          var parameters = (from p in constructor.GetParameters()
                            let g = GetParameterGenerator(type, p, context)
                            select g.Generate(context)).ToArray();

          return (TType)constructor.Invoke(parameters);
        }
      }

      return default;
    }

    /// <summary>
    /// Populates the provided instance with generated values.
    /// </summary>
    /// <typeparam name="TType">The type of instance to populate.</typeparam>
    /// <param name="instance">The instance to populate.</param>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance for the generate request.</param>
    /// <param name="members">An optional collection of members to populate. If null, all writable instance members are populated.</param>
    /// <remarks>
    /// Due to the boxing nature of value types, the <paramref name="instance"/> parameter is an object. This means the populated
    /// values are applied to the provided instance and not a copy.
    /// </remarks>
    public virtual void PopulateInstance<TType>(object instance, AutoGenerateContext context, IEnumerable<MemberInfo> members = null)
    {
      var type = typeof(TType);

      // We can only populate non-null instances 
      if (instance == null || context == null)
      {
        return;
      }

      // Iterate the members and bind a generated value
      var autoMembers = GetMembersToPopulate(type, members);

      foreach (var member in autoMembers)
      {
        if (member.Type != null)
        {
          // Check if the member has a skip config or the type has already been generated as a parent
          // If so skip this generation otherwise track it for use later in the object tree
          if (ShouldSkip(type, member, context))
          {
            continue;
          }

          context.ParentType = type;
          context.GenerateType = member.Type;
          context.GenerateName = member.Name;

          context.TypesStack.Push(member.Type);

          // Generate a random value and bind it to the instance
          var generator = AutoGeneratorFactory.GetGenerator(context);
          var value = generator.Generate(context);

          try
          {
            if (!member.IsReadOnly)
            {
              member.Setter.Invoke(instance, value);
            }
            else if (ReflectionHelper.IsDictionary(member.Type))
            {
              PopulateDictionary(value, instance, member);
            }
            else if (ReflectionHelper.IsCollection(member.Type))
            {
              PopulateCollection(value, instance, member);
            }
          }
          catch
          { }

          // Remove the current type from the type stack so siblings can be created
          context.TypesStack.Pop();
        }
      }
    }

    private bool ShouldSkip(Type type, AutoMember member, AutoGenerateContext context)
    {
      // Skip if the member type is found
      if (context.Config.SkipTypes.Contains(member.Type))
      {
        return true;
      }

      // Skip if the path is found (both current type and its implemented interfaces)
      if (context.Config.SkipPaths.Contains($"{type.FullName}.{member.Name}"))
      {
        return true;
      }
      foreach (var implementedInterfaceType in type.GetInterfaces())
      {
        if (context.Config.SkipPaths.Contains($"{implementedInterfaceType.FullName}.{member.Name}"))
        {
          return true;
        }
      }

      //check if tree depth is reached
      var treeDepth = context.Config.TreeDepth.Invoke(context);

      if (treeDepth.HasValue && context.TypesStack.Count() >= treeDepth)
        return true;

      // Finally check if the recursive depth has been reached

      var count = context.TypesStack.Count(t => t == member.Type);
      var recursiveDepth = context.Config.RecursiveDepth.Invoke(context);

      return count >= recursiveDepth;
    }

    private ConstructorInfo GetConstructor<TType>()
    {
      var type = typeof(TType);
      var constructors = type.GetConstructors();

      // For dictionaries and enumerables locate a constructor that is used for populating as well
      if (ReflectionHelper.IsDictionary(type))
      {
        return ResolveTypedConstructor(typeof(IDictionary<,>), constructors);
      }

      if (ReflectionHelper.IsEnumerable(type))
      {
        return ResolveTypedConstructor(typeof(IEnumerable<>), constructors);
      }

      // Attempt to find a default constructor
      // If one is not found, simply use the first in the list
      var defaultConstructor = (from c in constructors
                                let p = c.GetParameters()
                                where p.Count() == 0
                                select c).SingleOrDefault();

      return defaultConstructor ?? constructors.FirstOrDefault();
    }

    private ConstructorInfo ResolveTypedConstructor(Type type, IEnumerable<ConstructorInfo> constructors)
    {
      // Find the first constructor that matches the passed generic definition
      return (from c in constructors
              let p = c.GetParameters()
              where p.Count() == 1
              let m = p.Single()
              where ReflectionHelper.IsGenericType(m.ParameterType)
              let d = ReflectionHelper.GetGenericTypeDefinition(m.ParameterType)
              where d == type
              select c).SingleOrDefault();
    }

    private IAutoGenerator GetParameterGenerator(Type type, ParameterInfo parameter, AutoGenerateContext context)
    {
      context.ParentType = type;
      context.GenerateType = parameter.ParameterType;
      context.GenerateName = parameter.Name;

      return AutoGeneratorFactory.GetGenerator(context);
    }

    private IEnumerable<AutoMember> GetMembersToPopulate(Type type, IEnumerable<MemberInfo> members)
    {
      // If a list of members is provided, no others should be populated
      if (members != null)
      {
        return members.Select(member => new AutoMember(member));
      }

      // Get the baseline members resolved by Bogus
      var autoMembers = (from m in GetMembers(type)
                         select new AutoMember(m.Value)).ToList();

      foreach (var member in type.GetMembers(BindingFlags))
      {
        // Then check if any other members can be populated
        var autoMember = new AutoMember(member);

        if (!autoMembers.Any(baseMember => autoMember.Name == baseMember.Name))
        {
          // A readonly dictionary or collection member can use the Add() method
          if (autoMember.IsReadOnly && ReflectionHelper.IsDictionary(autoMember.Type))
          {
            autoMembers.Add(autoMember);
          }
          else if (autoMember.IsReadOnly && ReflectionHelper.IsCollection(autoMember.Type))
          {
            autoMembers.Add(autoMember);
          }
        }
      }

      return autoMembers;
    }

    private void PopulateDictionary(object value, object parent, AutoMember member)
    {
      var instance = member.Getter(parent);
      var argTypes = GetAddMethodArgumentTypes(member.Type);
      var addMethod = GetAddMethod(member.Type, argTypes);

      if (instance != null && addMethod != null && value is IDictionary dictionary)
      {
        foreach (var key in dictionary.Keys)
        {
          addMethod.Invoke(instance, new[] { key, dictionary[key] });
        }
      }
    }

    private void PopulateCollection(object value, object parent, AutoMember member)
    {
      var instance = member.Getter(parent);
      var argTypes = GetAddMethodArgumentTypes(member.Type);
      var addMethod = GetAddMethod(member.Type, argTypes);

      if (instance != null && addMethod != null && value is ICollection collection)
      {
        foreach (var item in collection)
        {
          addMethod.Invoke(instance, new[] { item });
        }
      }
    }

    private MethodInfo GetAddMethod(Type type, Type[] argTypes)
    {
      // First try directly on the type
      var method = type.GetMethod("Add", argTypes);

      if (method == null)
      {
        // Then traverse the type interfaces
        return (from i in type.GetInterfaces()
                let m = GetAddMethod(i, argTypes)
                where m != null
                select m).FirstOrDefault();
      }

      return method;
    }

    private Type[] GetAddMethodArgumentTypes(Type type)
    {
      var types = new[] { typeof(object) };

      if (ReflectionHelper.IsGenericType(type))
      {
        var generics = ReflectionHelper.GetGenericArguments(type);
        types = generics.ToArray();
      }

      return types;
    }
  }
}
