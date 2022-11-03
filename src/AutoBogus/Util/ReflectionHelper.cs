using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#if !NETSTANDARD1_3
using System.Dynamic;
#endif

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

    internal static bool IsExpandoObject(Type type)
    {
#if NETSTANDARD1_3
      return false;
#else
      return type == typeof(ExpandoObject);
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

    /// <summary>
    /// Return true if the type is a primitive type, date, decimal, string, or GUID
    /// </summary>
    /// <param name="type">Type for which to check if it is a simple type</param>
    internal static bool IsSimple(Type type)
    {
      if (type == null)
        return false;

      var typeInfo = type.GetTypeInfo();
      if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
      {
        // nullable type, check if the nested type is simple.
#if NETSTANDARD1_3
        var genericArgs = type.GetTypeInfo().IsGenericTypeDefinition 
          ? type.GetTypeInfo().GenericTypeParameters 
          : type.GetTypeInfo().GenericTypeArguments;
        return IsSimple(genericArgs[0]);
#else
        return IsSimple(typeInfo.GetGenericArguments()[0]);
#endif
      }
      return typeInfo.IsPrimitive
          || typeInfo.IsEnum
          || type.Equals(typeof(string))
          || type.Equals(typeof(decimal))
          || type.Equals(typeof(Guid))
          || type.Equals(typeof(DateTime))
          || type.Equals(typeof(DateTimeOffset));
    }

    internal static IEnumerable<Type> GetGenericArguments(Type type)
    {
      return type.GetGenericArguments();
    }

    internal static Type GetGenericTypeDefinition(Type type)
    {
      return type.GetGenericTypeDefinition();
    }

    internal static Type GetGenericCollectionType(Type type)
    {
      var interfaces = type.GetInterfaces().Where(ReflectionHelper.IsGenericType);

      if (IsInterface(type))
        interfaces = interfaces.Concat(new[] { type });

      Type dictionaryType = null;
      Type readOnlyDictionaryType = null;
      Type listType = null;
      Type setType = null;
      Type collectionType = null;
      Type enumerableType = null;

      foreach (var interfaceType in interfaces.Where(IsGenericType))
      {
        if (IsDictionary(interfaceType))
          dictionaryType = interfaceType;
        if (IsReadOnlyDictionary(interfaceType))
          readOnlyDictionaryType = interfaceType;
        if (IsList(interfaceType))
          listType = interfaceType;
        if (IsSet(interfaceType))
          setType = interfaceType;
        if (IsCollection(interfaceType))
          collectionType = interfaceType;
        if (IsEnumerable(interfaceType))
          enumerableType = interfaceType;
      }

      if ((dictionaryType != null) && (readOnlyDictionaryType != null) && IsReadOnlyDictionary(type))
        dictionaryType = null;

      return dictionaryType ?? readOnlyDictionaryType ?? listType ?? setType ?? collectionType ?? enumerableType;
    }

    internal static bool IsDictionary(Type type)
    {
      var baseType = typeof(IDictionary<,>);
      return IsGenericTypeDefinition(baseType, type);
    }

    internal static bool IsReadOnlyDictionary(Type type)
    {
#if NET40
      return false;
#else
      var baseType = typeof(IReadOnlyDictionary<,>);

      if (IsGenericTypeDefinition(baseType, type))
      {
        // Read only dictionaries don't have an Add() method
        var methods = type
          .GetMethods()
          .Where(m => m.Name.Equals("Add"));

        return !methods.Any();
      }

      return false;
#endif
    }

    internal static bool IsSet(Type type)
    {
      var baseType = typeof(ISet<>);
      return IsGenericTypeDefinition(baseType, type);
    }

    internal static bool IsList(Type type)
    {
      var baseType = typeof(IList<>);
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
