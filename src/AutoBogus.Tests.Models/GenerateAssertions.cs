using System;
using AutoBogus.Tests.Models.Complex;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using FluentAssertions;

namespace AutoBogus.Tests.Models
{
  public sealed class GenerateAssertions
    : ReferenceTypeAssertions<Order, GenerateAssertions>
  {
    private MethodInfo DefaultValueFactory;
    private IDictionary<Func<Type, bool>, Func<Type, object, bool>> Assertions = new Dictionary<Func<Type, bool>, Func<Type, object, bool>>();

    internal GenerateAssertions(Order order)
    {
      var type = GetType();

      Order = order;
      DefaultValueFactory = type.GetMethod("GetDefaultValue", BindingFlags.Instance | BindingFlags.NonPublic);

      // Add the assertions to type mappings
      Assertions.Add(IsInt, AssertInt);
      Assertions.Add(IsDecimal, AssertDecimal);
      Assertions.Add(IsGuid, AssertGuid);
      Assertions.Add(IsDateTime, AssertDateTime);
      Assertions.Add(IsString, AssertString);

      Assertions.Add(IsEnum, AssertEnum);
      Assertions.Add(IsNullable, AssertNullable);
      Assertions.Add(IsArray, AssertArray);
      Assertions.Add(IsDictionary, AssertDictionary);
      Assertions.Add(IsEnumerable, AssertEnumerable);

      Assertions.Add(IsInterface, AssertNull);
      Assertions.Add(IsAbstract, AssertNull);    
    }

    private Order Order { get; }
    private AssertionScope Scope { get; set; }

    protected override string Context => "order";

    public AndConstraint<Order> BePopulated()
    {
      var type = typeof(Order);
      var assertion = GetAssertion(type);

      Scope = Execute.Assertion;

      assertion.Invoke(type, Order);

      return new AndConstraint<Order>(Order);
    }

    public AndConstraint<Order> BeNotPopulated()
    {
      var type = typeof(Order);
      var memberInfos = GetMemberInfos(type);

      Scope = Execute.Assertion;

      foreach (var memberInfo in memberInfos)
      {
        AssertDefaultValue(memberInfo);
      }

      return new AndConstraint<Order>(Order);
    }

    private void AssertDefaultValue(MemberInfo memberInfo)
    {
      ExtractMemberInfo(memberInfo, out Type memberType, out Func<object, object> memberGetter);

      // Resolve the default value for the current member type and check it matches
      var factory = DefaultValueFactory.MakeGenericMethod(memberType);
      var defaultValue = factory.Invoke(this, new object[0]);
      var value = memberGetter.Invoke(Order);
      var equal = value == null && defaultValue == null;

      if (!equal)
      {
        // Ensure Equals() is called on a non-null instance
        if (value != null)
        {
          equal = value.Equals(defaultValue);
        }
        else
        {
          equal = defaultValue.Equals(value);
        }
      }

      Scope = Scope
        .ForCondition(equal)
        .FailWith($"Expected a default '{memberType.FullName}' value for '{memberInfo.Name}'.")
        .Then;
    }

    private bool AssertType(Type type, object instance)
    {
      // Iterate the members for the instance and assert their values
      var members = GetMemberInfos(type);

      foreach (var member in members)
      {
        AssertMember(member, instance);
      }

      return true;
    }

    private void AssertMember(MemberInfo memberInfo, object instance)
    {
      ExtractMemberInfo(memberInfo, out Type memberType, out Func<object, object> memberGetter);

      // Resolve the assertion and value for the member type
      var value = memberGetter.Invoke(instance);
      var assertion = GetAssertion(memberType);
      var result = assertion.Invoke(memberType, value);

      // Register an assertion for each member
      Scope = Scope
        .ForCondition(result)
        .FailWith($"Expected a value of type '{memberType.FullName}' for '{memberInfo.Name}'.")
        .Then;
    }

    private static bool IsInt(Type type) => type == typeof(int);
    private static bool IsDecimal(Type type) => type == typeof(decimal);
    private static bool IsGuid(Type type) => type == typeof(Guid);
    private static bool IsDateTime(Type type) => type == typeof(DateTime);
    private static bool IsString(Type type) => type == typeof(string);
    private static bool IsEnum(Type type) => type.GetTypeInfo().IsEnum;
    private static bool IsNullable(Type type) => type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
    private static bool IsArray(Type type) => type.IsArray;
    private static bool IsDictionary(Type type) => IsType(type, typeof(IDictionary<,>));
    private static bool IsEnumerable(Type type) => IsType(type, typeof(IEnumerable<>));
    private static bool IsAbstract(Type type) => type.GetTypeInfo().IsAbstract;
    private static bool IsInterface(Type type) => type.GetTypeInfo().IsInterface;

    private static bool AssertInt(Type type, object value) => !value.Equals(0);
    private static bool AssertDecimal(Type type, object value) => !value.Equals(0d);
    private static bool AssertGuid(Type type, object value) => Guid.TryParse(value.ToString(), out Guid result);
    private static bool AssertDateTime(Type type, object value) => DateTime.TryParse(value.ToString(), out DateTime result);
    private static bool AssertEnum(Type type, object value) => Enum.IsDefined(type, value);
    private static bool AssertNull(Type type, object value) => value == null;

    private static bool AssertString(Type type, object value)
    {
      var str = value?.ToString();
      return !string.IsNullOrWhiteSpace(str);
    }

    private bool AssertNullable(Type type, object value)
    {
      var genericType = type.GenericTypeArguments.Single();
      var assertion = GetAssertion(genericType);

      return assertion.Invoke(genericType, value);
    }

    private bool AssertArray(Type type, object value)
    {
      var itemType = type.GetElementType();
      return AssertItems(itemType, value as Array);
    }

    private bool AssertDictionary(Type type, object value)
    {
      return true;
    }

    private bool AssertEnumerable(Type type, object value)
    {
      var typeInfo = type.GetTypeInfo();
      var genericTypes = typeInfo.GetGenericArguments();
      var itemType = genericTypes.Single();

      return AssertItems(itemType, value as IEnumerable);
    }

    private bool AssertItems(Type type, IEnumerable items)
    {
      // Check the list of items is not null
      if (items == null)
      {
        return false;
      }

      // Check the count state of the items
      var count = 0;
      var enumerator = items.GetEnumerator();

      while (enumerator.MoveNext())
      {
        count++;
      }

      if (count > 0)
      {
        // If we have any items, check each of them 
        var assertion = GetAssertion(type);

        foreach (var item in items)
        {
          if (!assertion.Invoke(type, item))
          {
            return false;
          }
        }
      }
      else
      {
        // Otherwise ensure we are not dealing with interface or abstract class
        // These types will result in an empty list by default because they cannot be generated
        var typeInfo = type.GetTypeInfo();

        if (!typeInfo.IsInterface && !typeInfo.IsAbstract)
        {
          return false;
        }
      }

      return true;
    }

    private object GetDefaultValue<TType>()
    {
      return default(TType);
    }

    private static bool IsType(Type type, Type baseType)
    {
      var typeInfo = type.GetTypeInfo();
      var baseTypeInfo = baseType.GetTypeInfo();

      // We may need to do some generics magic to compare the types
      if (typeInfo.IsGenericType && baseTypeInfo.IsGenericType)
      {
        var types = typeInfo.GetGenericArguments();
        var baseTypes = baseType.GetGenericArguments();

        if (types.Length == baseTypes.Length)
        {
          baseType = baseType.MakeGenericType(types);
        }
      }

      return baseType.IsAssignableFrom(type);
    }

    private Func<Type, object, bool> GetAssertion(Type type)
    {
      var assertion = (from k in Assertions.Keys
                       where k.Invoke(type)
                       select Assertions[k]).FirstOrDefault();

      return assertion ?? AssertType;
    }

    private IEnumerable<MemberInfo> GetMemberInfos(Type type)
    {
      return (from m in type.GetMembers()
              where m.MemberType == MemberTypes.Property || m.MemberType == MemberTypes.Field
              select m);
    }

    private static void ExtractMemberInfo(MemberInfo member, out Type memberType, out Func<object, object> memberGetter)
    {
      memberType = null;
      memberGetter = null;

      // Extract the member type and getter action
      if (member.MemberType == MemberTypes.Field)
      {
        var fieldInfo = member as FieldInfo;

        memberType = fieldInfo.FieldType;
        memberGetter = fieldInfo.GetValue;
      }
      else if (member.MemberType == MemberTypes.Property)
      {
        var propertyInfo = member as PropertyInfo;

        memberType = propertyInfo.PropertyType;
        memberGetter = propertyInfo.GetValue;
      }
    }
  }
}
