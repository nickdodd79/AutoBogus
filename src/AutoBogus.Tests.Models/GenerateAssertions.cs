using AutoBogus.Util;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoBogus.Tests.Models
{
  public sealed class GenerateAssertions
    : ReferenceTypeAssertions<object, GenerateAssertions>
  {
    private MethodInfo DefaultValueFactory;
    private IDictionary<Func<Type, bool>, Func<string, Type, object, string>> Assertions = new Dictionary<Func<Type, bool>, Func<string, Type, object, string>>();

    internal GenerateAssertions(object subject)
    {
      var type = GetType();

      Subject = subject;
      DefaultValueFactory = type.GetMethod("GetDefaultValue", BindingFlags.Instance | BindingFlags.NonPublic);

      // Add the assertions to type mappings
      Assertions.Add(IsBool, AssertBool);
      Assertions.Add(IsByte, AssertByte);
      Assertions.Add(IsChar, AssertChar);
      Assertions.Add(IsDateTime, AssertDateTime);
      Assertions.Add(IsDateTimeOffset, AssertDateTimeOffset);
      Assertions.Add(IsDecimal, AssertDecimal);
      Assertions.Add(IsDouble, AssertDouble);
      Assertions.Add(IsFloat, AssertFloat);
      Assertions.Add(IsGuid, AssertGuid);
      Assertions.Add(IsInt, AssertInt);
      Assertions.Add(IsLong, AssertLong);
      Assertions.Add(IsSByte, AssertSByte);
      Assertions.Add(IsShort, AssertShort);
      Assertions.Add(IsString, AssertString);
      Assertions.Add(IsUInt, AssertUInt);
      Assertions.Add(IsULong, AssertULong);
      Assertions.Add(IsUri, AssertUri);
      Assertions.Add(IsUShort, AssertUShort);

      Assertions.Add(IsArray, AssertArray);
      Assertions.Add(IsEnum, AssertEnum);
      Assertions.Add(IsDictionary, AssertDictionary);
      Assertions.Add(IsEnumerable, AssertEnumerable);
      Assertions.Add(IsNullable, AssertNullable);
    }

    private AssertionScope Scope { get; set; }

    protected override string Identifier => "Generate";

    public AndConstraint<object> BeGenerated()
    {
      var type = Subject.GetType();
      var assertion = GetAssertion(type);

      Scope = Execute.Assertion;

      // Assert the value and output any fail messages
      var message = assertion.Invoke(null, type, Subject);
            
      Scope = Scope
        .ForCondition(message == null)
        .FailWith(message)
        .Then;

      return new AndConstraint<object>(Subject);
    }

    public AndConstraint<object> BeGeneratedWithMocks()
    {
      // Ensure the mocked objects are asserted as not null
      Assertions.Add(IsInterface, AssertMock);
      Assertions.Add(IsAbstract, AssertMock);

      return AssertSubject();
    }

    public AndConstraint<object> BeGeneratedWithoutMocks()
    {
      // Ensure the mocked objects are asserted as null
      Assertions.Add(IsInterface, AssertNull);
      Assertions.Add(IsAbstract, AssertNull);

      return AssertSubject();
    }

    public AndConstraint<object> NotBeGenerated()
    {
      var type = Subject.GetType();
      var memberInfos = GetMemberInfos(type);

      Scope = Execute.Assertion;

      foreach (var memberInfo in memberInfos)
      {
        AssertDefaultValue(memberInfo);
      }

      return new AndConstraint<object>(Subject);
    }

    private AndConstraint<object> AssertSubject()
    {
      var type = Subject.GetType();
      var assertion = GetAssertion(type);

      Scope = Execute.Assertion;

      assertion.Invoke(type.Name, type, Subject);

      return new AndConstraint<object>(Subject);
    }

    private string AssertType(string path, Type type, object instance)
    {
      // Iterate the members for the instance and assert their values
      var members = GetMemberInfos(type);

      foreach (var member in members)
      {
        AssertMember(path, member, instance);
      }

      return null;
    }

    private void AssertDefaultValue(MemberInfo memberInfo)
    {
      ExtractMemberInfo(memberInfo, out Type memberType, out Func<object, object> memberGetter);

      // Resolve the default value for the current member type and check it matches
      var factory = DefaultValueFactory.MakeGenericMethod(memberType);
      var defaultValue = factory.Invoke(this, new object[0]);
      var value = memberGetter.Invoke(Subject);
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

    private static bool IsBool(Type type) => type == typeof(bool);
    private static bool IsByte(Type type) => type == typeof(byte);
    private static bool IsChar(Type type) => type == typeof(char);
    private static bool IsDateTime(Type type) => type == typeof(DateTime);
    private static bool IsDateTimeOffset(Type type) => type == typeof(DateTimeOffset);
    private static bool IsDecimal(Type type) => type == typeof(decimal);
    private static bool IsDouble(Type type) => type == typeof(double);
    private static bool IsFloat(Type type) => type == typeof(float);
    private static bool IsGuid(Type type) => type == typeof(Guid);
    private static bool IsInt(Type type) => type == typeof(int);
    private static bool IsLong(Type type) => type == typeof(long);
    private static bool IsSByte(Type type) => type == typeof(sbyte);
    private static bool IsShort(Type type) => type == typeof(short);
    private static bool IsString(Type type) => type == typeof(string);
    private static bool IsUInt(Type type) => type == typeof(uint);
    private static bool IsULong(Type type) => type == typeof(ulong);
    private static bool IsUri(Type type) => type == typeof(Uri);
    private static bool IsUShort(Type type) => type == typeof(ushort);
    private static bool IsArray(Type type) => type.IsArray;
    private static bool IsEnum(Type type) => ReflectionHelper.IsEnum(type);
    private static bool IsDictionary(Type type) => IsType(type, typeof(IDictionary<,>));
    private static bool IsEnumerable(Type type) => IsType(type, typeof(IEnumerable<>));
    private static bool IsNullable(Type type) => ReflectionHelper.IsGenericType(type) && type.GetGenericTypeDefinition() == typeof(Nullable<>);
    private static bool IsAbstract(Type type) => ReflectionHelper.IsAbstract(type);
    private static bool IsInterface(Type type) => ReflectionHelper.IsInterface(type);

    private static string AssertBool(string path, Type type, object value) => value != null && bool.TryParse(value.ToString(), out bool result) ? null : GetAssertionMessage(path, type, value);
    private static string AssertByte(string path, Type type, object value) => value != null && byte.TryParse(value.ToString(), out byte result) ? null : GetAssertionMessage(path, type, value);
    private static string AssertChar(string path, Type type, object value) => value != null && char.TryParse(value.ToString(), out char result) && result != default(char) ? null : GetAssertionMessage(path, type, value);
    private static string AssertDateTime(string path, Type type, object value) => value != null && DateTime.TryParse(value.ToString(), out DateTime result) && result != default(DateTime) ? null : GetAssertionMessage(path, type, value);
    private static string AssertDateTimeOffset(string path, Type type, object value) => value != null && DateTimeOffset.TryParse(value.ToString(), out DateTimeOffset result) && result != default(DateTimeOffset) ? null : GetAssertionMessage(path, type, value);
    private static string AssertDecimal(string path, Type type, object value) => value != null && decimal.TryParse(value.ToString(), out decimal result) && result != default(decimal) ? null : GetAssertionMessage(path, type, value);
    private static string AssertDouble(string path, Type type, object value) => value != null && double.TryParse(value.ToString(), out double result) && result != default(double) ? null : GetAssertionMessage(path, type, value);
    private static string AssertFloat(string path, Type type, object value) => value != null && float.TryParse(value.ToString(), out float result) && result != default(float) ? null : GetAssertionMessage(path, type, value);
    private static string AssertGuid(string path, Type type, object value) => value != null && Guid.TryParse(value.ToString(), out Guid result) && result != default(Guid) ? null : GetAssertionMessage(path, type, value);
    private static string AssertInt(string path, Type type, object value) => value != null && int.TryParse(value.ToString(), out int result) && result != default(int) ? null : GetAssertionMessage(path, type, value);
    private static string AssertLong(string path, Type type, object value) => value != null && long.TryParse(value.ToString(), out long result) && result != default(long) ? null : GetAssertionMessage(path, type, value);
    private static string AssertSByte(string path, Type type, object value) => value != null && sbyte.TryParse(value.ToString(), out sbyte result) ? null : GetAssertionMessage(path, type, value);
    private static string AssertShort(string path, Type type, object value) => value != null && short.TryParse(value.ToString(), out short result) && result != default(short) ? null : GetAssertionMessage(path, type, value);
    private static string AssertUInt(string path, Type type, object value) => value != null && uint.TryParse(value.ToString(), out uint result) && result != default(uint) ? null : GetAssertionMessage(path, type, value);
    private static string AssertULong(string path, Type type, object value) => value != null && ulong.TryParse(value.ToString(), out ulong result) && result != default(ulong) ? null : GetAssertionMessage(path, type, value);
    private static string AssertUri(string path, Type type, object value) => value != null && Uri.IsWellFormedUriString(value.ToString(), UriKind.RelativeOrAbsolute) ? null : GetAssertionMessage(path, type, value);
    private static string AssertUShort(string path, Type type, object value) => value != null && ushort.TryParse(value.ToString(), out ushort result) && result != default(ushort) ? null : GetAssertionMessage(path, type, value);
    private static string AssertEnum(string path, Type type, object value) => value != null && Enum.IsDefined(type, value) ? null : GetAssertionMessage(path, type, value);
    private static string AssertNull(string path, Type type, object value) => value == null ? null : $"Expected value to be null for '{path}'.";

    private static string AssertString(string path, Type type, object value)
    {
      var str = value?.ToString();
      return string.IsNullOrWhiteSpace(str) ? GetAssertionMessage(path, type, value) : null ;
    }

    private string AssertNullable(string path, Type type, object value)
    {
      var genericType = type.GenericTypeArguments.Single();
      var assertion = GetAssertion(genericType);

      return assertion.Invoke(path, genericType, value);
    }

    private string AssertMock(string path, Type type, object value)
    {
      if (value == null)
      {
        return $"Excepted value to not be null for '{path}'.";
      }

      // Assert via assignment rather than explicit checks (the actual instance could be a sub class)
      var valueType = value.GetType();
      return type.IsAssignableFrom(valueType) ? null : GetAssertionMessage(path, type, value);
    }

    private string AssertArray(string path, Type type, object value)
    {
      var itemType = type.GetElementType();
      return AssertItems(path, itemType, value as Array);
    }

    private string AssertDictionary(string path, Type type, object value)
    {
      var genericTypes = type.GetGenericArguments();
      var keyType = genericTypes.ElementAt(0);
      var valueType = genericTypes.ElementAt(1);
      var dictionary = value as IDictionary;

      if (dictionary == null)
      {
        return $"Excepted value to not be null for '{path}'.";
      }

      // Check the keys and values individually
      var keysMessage = AssertItems(path, keyType, dictionary.Keys, "keys", ".Key");

      if (keysMessage == null)
      {
        return AssertItems(path, valueType, dictionary.Values, "values", ".Value");
      }

      return keysMessage;      
    }

    private string AssertEnumerable(string path, Type type, object value)
    {
      var genericTypes = type.GetGenericArguments();
      var itemType = genericTypes.Single();

      return AssertItems(path, itemType, value as IEnumerable);
    }

    private string AssertItems(string path, Type type, IEnumerable items, string elementType = null, string suffix = null)
    {
      // Check the list of items is not null
      if (items == null)
      {
        return $"Excepted value to not be null for '{path}'.";
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
        var index = 0;
        var assertion = GetAssertion(type);

        foreach (var item in items)
        {
          var element = string.Format("{0}[{1}]{2}", path, index++, suffix);
          var message = assertion.Invoke(element, type, item);

          if (message != null)
          {
            return message;
          }
        }
      }
      else
      {
        // Otherwise ensure we are not dealing with interface or abstract class
        // These types will result in an empty list by default because they cannot be generated
        if (!ReflectionHelper.IsInterface(type) && !ReflectionHelper.IsAbstract(type))
        {
          elementType = elementType ?? "value";
          return $"Excepted {elementType} to not be empty for '{path}'.";
        }
      }

      return null;
    }

    private void AssertMember(string path, MemberInfo memberInfo, object instance)
    {
      ExtractMemberInfo(memberInfo, out Type memberType, out Func<object, object> memberGetter);

      // Create a trace path for the current member
      path = string.Concat(path, ".", memberInfo.Name);

      // Resolve the assertion and value for the member type      
      if (instance != null)
      {
        var value = memberGetter.Invoke(instance);
        var assertion = GetAssertion(memberType);
        var message = assertion.Invoke(path, memberType, value);

        // Register an assertion for each member
        Scope = Scope
          .ForCondition(message == null)
          .FailWith(message)
          .Then;
      }
    }

    private object GetDefaultValue<TType>()
    {
      return default(TType);
    }

    private static string GetAssertionMessage(string path, Type type, object value)
    {
      return string.IsNullOrWhiteSpace(path)
        ? $"Excepted a value of type '{type.FullName}' -> {value ?? "?"}."
        : $"Excepted a value of type '{type.FullName}' for '{path}' -> {value ?? "?"}.";
    }

    private Func<string, Type, object, string> GetAssertion(Type type)
    {
      var assertion = (from k in Assertions.Keys
                       where k.Invoke(type)
                       select Assertions[k]).FirstOrDefault();

      return assertion ?? AssertType;
    }

    private IEnumerable<MemberInfo> GetMemberInfos(Type type)
    {
      return (from m in type.GetMembers()
              where ReflectionHelper.IsField(m) || ReflectionHelper.IsProperty(m)
              select m);
    }

    private static bool IsType(Type type, Type baseType)
    {
      // We may need to do some generics magic to compare the types
      if (ReflectionHelper.IsGenericType(type) && ReflectionHelper.IsGenericType(baseType))
      {
        var types = type.GetGenericArguments();
        var baseTypes = baseType.GetGenericArguments();

        if (types.Length == baseTypes.Length)
        {
          baseType = baseType.MakeGenericType(types);
        }
      }

      return baseType.IsAssignableFrom(type);
    }

    private static void ExtractMemberInfo(MemberInfo member, out Type memberType, out Func<object, object> memberGetter)
    {
      memberType = null;
      memberGetter = null;

      // Extract the member type and getter action
      if (ReflectionHelper.IsField(member))
      {
        var fieldInfo = member as FieldInfo;

        memberType = fieldInfo.FieldType;
        memberGetter = fieldInfo.GetValue;
      }
      else if (ReflectionHelper.IsProperty(member))
      {
        var propertyInfo = member as PropertyInfo;

        memberType = propertyInfo.PropertyType;
        memberGetter = propertyInfo.GetValue;
      }
    }
  }
}
