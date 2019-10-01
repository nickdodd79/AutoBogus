using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoBogus.Util
{
  internal static class ReflectionHelper
  {
    internal static bool IsEnum(Type type)
    {
#if NET40
      return type.IsEnum;
#else
      var typeInfo = type.GetTypeInfo();
      return typeInfo.IsEnum;
#endif
    }

    internal static bool IsAbstract(Type type)
    {
#if NET40
      return type.IsAbstract;
#else
      var typeInfo = type.GetTypeInfo();
      return typeInfo.IsAbstract;
#endif
    }

    internal static bool IsInterface(Type type)
    {
#if NET40
      return type.IsInterface;
#else
      var typeInfo = type.GetTypeInfo();
      return typeInfo.IsInterface;
#endif
    }

    internal static bool IsGenericType(Type type)
    {
#if NET40
      return type.IsGenericType;
#else
      var typeInfo = type.GetTypeInfo();
      return typeInfo.IsGenericType;
#endif
    }

    internal static bool IsAssignableFrom(Type baseType, Type type)
    {
#if NET40
      return baseType.IsAssignableFrom(type);
#else
      var baseTypeInfo = baseType.GetTypeInfo();
      var typeInfo = type.GetTypeInfo();
      
      return baseTypeInfo.IsAssignableFrom(typeInfo);
#endif
    }

    internal static bool IsField(MemberInfo member)
    {
#if NET40
      return member.MemberType == MemberTypes.Field;
#else
      return member is FieldInfo;
#endif
    }

    internal static bool IsProperty(MemberInfo member)
    {
#if NET40
      return member.MemberType == MemberTypes.Property;
#else
      return member is PropertyInfo;
#endif
    }

    internal static IEnumerable<Type> GetGenericArguments(Type type)
    {
      return type.GetGenericArguments();
    }

    internal static Type GetGenericTypeDefinition(Type type)
    {
      return type.GetGenericTypeDefinition();
    }

    internal static bool IsDictionary(Type type)
    {
      var baseType = typeof(IDictionary<,>);
      return IsGenericTypeDefinition(baseType, type);
    }

#if NETSTANDARD1_3 || NETSTANDARD2_0
    internal static bool IsReadOnlyDictionary(Type type)
    {
      var baseType = typeof(IReadOnlyDictionary<,>);
      return IsGenericTypeDefinition(baseType, type);
    }
#endif

    internal static bool IsSet(Type type)
    {
      var baseType = typeof(ISet<>);
      return IsGenericTypeDefinition(baseType, type);
    }

    internal static bool IsCollection(Type type)
    {
      var baseType = typeof(ICollection<>);
      return IsGenericTypeDefinition(baseType, type);
    }

    internal static bool IsEnumerable(Type type)
    {
      var baseType = typeof(IEnumerable<>);
      return IsGenericTypeDefinition(baseType, type);
    }

    internal static bool IsNullable(Type type)
    {
      return IsGenericTypeDefinition(typeof(Nullable<>), type);
    }

    private static bool IsGenericTypeDefinition(Type baseType, Type type)
    {
      if (IsGenericType(type))
      {
        var definition = GetGenericTypeDefinition(type);

        // Do an assignable query first
        if (IsAssignableFrom(baseType, definition))
        {
          return true;
        }

        // If that don't work use the more complex interface checks
        var interfaces = (from i in type.GetInterfaces()
                          where IsGenericTypeDefinition(baseType, i)
                          select i);

        return interfaces.Any();
      }

      return false;
    }
  }
}
