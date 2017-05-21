using Bogus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoBogus
{
  public class AutoBinder
    : Binder, IAutoBinder
  {
    private static readonly Type EnumerableType = typeof(IEnumerable);
    private static readonly Type DictionaryType = typeof(IDictionary);

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

    public virtual void PopulateInstance<TType>(object instance, AutoGenerateContext context, IEnumerable<MemberInfo> members = null)
    {
      var type = typeof(TType);

      // We can only populate non-null instance 
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
          // Generate a random value and bind it to the instance
          var generator = AutoGeneratorFactory.GetGenerator(memberType, context);
          var value = generator.Generate(context);

          memberSetter.Invoke(instance, value);
        }
      }
    }

    private bool IsDictionary(Type type)
    {
      return DictionaryType.IsAssignableFrom(type);
    }

    private bool IsEnumerable(Type type)
    {
      return EnumerableType.IsAssignableFrom(type);
    }

    private ConstructorInfo GetConstructor<TType>()
    {
      var type = typeof(TType);
      var typeInfo = type.GetTypeInfo();
      var constructors = typeInfo.GetConstructors();

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
              let i = m.ParameterType.GetTypeInfo()
              where i.IsGenericType
              let d = m.ParameterType.GetGenericTypeDefinition()
              where d == type
              select c).SingleOrDefault();
    }

    private void ExtractMemberInfo(MemberInfo member, out Type memberType, out Action<object, object> memberSetter)
    {
      memberType = null;
      memberSetter = null;

      // Extract the member type and setter action
      if (member.MemberType == MemberTypes.Field)
      {
        var fieldInfo = member as FieldInfo;

        memberType = fieldInfo.FieldType;
        memberSetter = fieldInfo.SetValue;
      }
      else if (member.MemberType == MemberTypes.Property)
      {
        var propertyInfo = member as PropertyInfo;

        memberType = propertyInfo.PropertyType;
        memberSetter = propertyInfo.SetValue;
      }
    }
  }
}
