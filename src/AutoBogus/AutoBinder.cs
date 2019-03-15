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
  /// An class for binding auto generated instances.
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
      var constructor = GetConstructor<TType>();

      if (constructor != null)
      {
        // If a constructor is found generate values for each of the parameters
        var parameters = (from p in constructor.GetParameters()
                          let g = AutoGeneratorFactory.GetGenerator(p.ParameterType, context)
                          select g.Generate(context)).ToArray();

        return (TType)constructor.Invoke(parameters);
      }

      return default(TType);
    }

    /// <summary>
    /// Populates the provided instance with auto generated values.
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
      // Dictionaries and Enumerables are populated via their constructors
      if (instance == null || IsDictionary(type) || IsEnumerable(type))
      {
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
          // Check if the type has already been generated as a parent
          // If so skip this generation otherwise track it for use later in the object tree
          if (context.Types.Contains(memberType))
          {
            continue;
          }

          context.MemberName = member.Name;
          context.MemberType = memberType;

          context.Types.Push(memberType);

          // Generate a random value and bind it to the instance
          var generator = AutoGeneratorFactory.GetGenerator(memberType, context);
          var value = generator.Generate(context);

          memberSetter.Invoke(instance, value);

          // Remove the current type from the type stack so siblings can be created
          context.Types.Pop();
        }
      }
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
        memberSetter = (obj, value) => propertyInfo.SetValue(obj, value, new object[0]);
      }
    }
  }
}
