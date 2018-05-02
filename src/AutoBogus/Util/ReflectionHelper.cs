using System;
using System.Collections.Generic;
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

    internal static bool IsArray(Type type)
    {
      return type.IsArray;
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

    internal static IEnumerable<ConstructorInfo> GetConstructors(Type type)
    {
      return type.GetConstructors();
    }

    internal static Type GetGenericTypeDefinition(Type type)
    {
      return type.GetGenericTypeDefinition();
    }

    internal static IEnumerable<Type> GetGenericArguments(Type type)
    {
      return type.GetGenericArguments();
    }
  }
}
