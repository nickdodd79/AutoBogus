using AutoBogus.Util;
using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Allow read-only IList members because they can be set by adding items to the list.
    /// </summary>
    /// <returns>The full set of MemberInfos for injection.</returns>
    public override Dictionary<string, MemberInfo> GetMembers(Type t)
    {
      var memberDictionary = base.GetMembers(t);

      // Find the read-only IList members
      var group = t.GetMembers(BindingFlags)
         .Where(m =>
         {
           if (m is PropertyInfo pi)
           {
             return !pi.CanWrite && pi.PropertyType.GetInterfaces().Contains(typeof(IList));
           }
           return false;
         })
         .GroupBy(mi => mi.Name);

      // Add them to the dictionary from the base implementation
      foreach (var item in group.ToDictionary(k => k.Key, g => g.First()))
      {
        memberDictionary[item.Key] = item.Value;
      }

      return memberDictionary;
    }

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
        var constructor = GetConstructor<TType>();

        if (constructor != null)
        {
          // If a constructor is found generate values for each of the parameters
          var parameters = (from p in constructor.GetParameters()
                            let g = GetParameterGenerator(p, context)
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
      // Dictionaries are populated via their constructors
      if (instance == null || context == null || IsDictionary(type))
      {
        return;
      }

      // If the Enumerable instance was not populated via constructor,
      // populate it via IList.Add(), if available.
      if (IsEnumerable(type))
      {
        var instanceAsList = instance as IList;
        if (instanceAsList != null && instanceAsList.Count == 0)
        {
          // TType is a RepeatedField<EmbeddedType>, construct a List<EmbeddedType>,
          // populate it via the AutoGenerator, then copy the contents to the RepeatedField
          var genericType = type.GetGenericArguments().ElementAt(0);
          var listType = typeof(List<>).MakeGenericType(new[] { genericType });

          context.GenerateType = listType;
          context.GenerateName = listType.Name;

          context.TypesStack.Push(listType);

          // Generate random values for a List
          var generator = AutoGeneratorFactory.GetGenerator(context);
          var value = generator.Generate(context);

          // Add them to the RepeatedField instance
          foreach (var v in (value as IList))
          {
            instanceAsList.Add(v);
          }

          // Remove the current type from the type stack so siblings can be created
          context.TypesStack.Pop();
        }
        return;
      }

      // If no members are provided, get all value candidates for the instance
      if (members == null)
      {
        members = (from m in GetMembers(type)
                   select m.Value);
      }
      
      // Iterate the members and bind a generated value
      foreach (var member in members)
      {
        // We may be resolving a field or property, but both provide a type and setter action
        ExtractMemberInfo(member, out Type memberType, out Action<object, object> memberSetter);

        if (memberType != null && memberSetter != null)
        {
          // Check if the member has a skip config or the type has already been generated as a parent
          // If so skip this generation otherwise track it for use later in the object tree
          if (ShouldSkip(memberType, $"{type.FullName}.{member.Name}", context))
          {
            continue;
          }

          context.GenerateType = memberType;
          context.GenerateName = member.Name;

          context.TypesStack.Push(memberType);

          // Generate a random value and bind it to the instance
          var generator = AutoGeneratorFactory.GetGenerator(context);
          var value = generator.Generate(context);

          memberSetter.Invoke(instance, value);

          // Remove the current type from the type stack so siblings can be created
          context.TypesStack.Pop();
        }
      }
    }

    private bool ShouldSkip(Type type, string path, AutoGenerateContext context)
    {
      var count = context.TypesStack.Count(t => t == type);
      return context.Config.Skips.Contains(path) || count >= context.Config.RecursiveDepth;
    }

    private bool IsDictionary(Type type)
    {
      return ReflectionHelper.IsAssignableFrom(typeof(IDictionary), type);
    }

    private bool IsEnumerable(Type type)
    {
      return ReflectionHelper.IsAssignableFrom(typeof(IEnumerable), type);
    }

    private ConstructorInfo GetConstructor<TType>()
    {
      var type = typeof(TType);
      var constructors = type.GetConstructors();

      // For dictionaries and enumerables locate a constructor that is used for populating as well
      if (IsDictionary(type))
      {
        return ResolveTypedConstructor(typeof(IDictionary<,>), constructors);
      }

      if (IsEnumerable(type))
      {
        var constructorInfo = ResolveTypedConstructor(typeof(IEnumerable<>), constructors);
        if (constructorInfo != null)
        {
          return constructorInfo;
        }
      }

      // Attempt to find a default constructor
      // If one is not found, simply use the first in the list
      var defaultConstructor = (from c in constructors
                                let p = c.GetParameters()
                                where p.Count() == 0
                                select c).SingleOrDefault();

      return defaultConstructor ?? constructors.FirstOrDefault();
    }

    private IAutoGenerator GetParameterGenerator(ParameterInfo parameter, AutoGenerateContext context)
    {
      context.GenerateType = parameter.ParameterType;
      context.GenerateName = parameter.Name;

      return AutoGeneratorFactory.GetGenerator(context);
    }

    private ConstructorInfo ResolveTypedConstructor(Type type, IEnumerable<ConstructorInfo> constructors)
    {
      // Find the first constructor that matches the passed generic definition
      return (from c in constructors
              let p = c.GetParameters()
              where p.Count() == 1
              let m = p.Single()
              where ReflectionHelper.IsGenericType(m.ParameterType)
              let d = m.ParameterType.GetGenericTypeDefinition()
              where d == type
              select c).SingleOrDefault();
    }

    private void ExtractMemberInfo(MemberInfo member, out Type memberType, out Action<object, object> memberSetter)
    {
      memberType = null;
      memberSetter = null;

      // Extract the member type and setter action
      if (ReflectionHelper.IsField(member))
      {
        var fieldInfo = member as FieldInfo;

        memberType = fieldInfo.FieldType;
        memberSetter = fieldInfo.SetValue;
      }
      else if (ReflectionHelper.IsProperty(member))
      {
        var propertyInfo = member as PropertyInfo;

        memberType = propertyInfo.PropertyType;
        memberSetter = (obj, value) =>
        {
          if (propertyInfo.CanWrite)
          {
            propertyInfo.SetValue(obj, value, new object[0]);
          }
          else
          {
            foreach (var v in (value as IList))
            {
              (propertyInfo.GetValue(obj, new object[0]) as IList).Add(v);
            }
          }
        };
      }
    }
  }
}
