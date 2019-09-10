using AutoBogus.Util;
using System;
using System.Reflection;

namespace AutoBogus
{
  internal sealed class AutoMember
  {
    internal AutoMember(MemberInfo memberInfo)
    {
      Name = memberInfo.Name;

      // Extract the required member info
      if (ReflectionHelper.IsField(memberInfo))
      {
        var fieldInfo = memberInfo as FieldInfo;

        Type = fieldInfo.FieldType;
        IsReadOnly = !fieldInfo.IsPrivate && fieldInfo.IsInitOnly;
        Getter = fieldInfo.GetValue;
        Setter = fieldInfo.SetValue;
      }
      else if (ReflectionHelper.IsProperty(memberInfo))
      {
        var propertyInfo = memberInfo as PropertyInfo;

        Type = propertyInfo.PropertyType;
        IsReadOnly = !propertyInfo.CanWrite;
        Getter = obj => propertyInfo.GetValue(obj, new object[0]);
        Setter = (obj, value) => propertyInfo.SetValue(obj, value, new object[0]);
      }
    }

    internal string Name { get; }
    internal Type Type { get; }
    internal bool IsReadOnly { get; }
    internal Func<object, object> Getter { get; }
    internal Action<object, object> Setter { get; }
  }
}
