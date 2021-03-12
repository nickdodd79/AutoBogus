using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoBogus.Templating
{
  internal class ReflectionHelper
  {
    public static Type GetPropType(object src, string propName)
    {
      return src.GetType().GetProperty(propName)!.PropertyType;
    }

    public static MethodInfo GetMethod(Type t, string n, Type[] genargs, Type[] args)
    {
      var methods =
          from m in t.GetMethods()
          where m.Name == n && m.GetGenericArguments().Length == genargs.Length
          let mg = m.IsGenericMethodDefinition ? m.MakeGenericMethod(genargs) : m
          where mg.GetParameters().Select(p => p.ParameterType).SequenceEqual(args)
          select mg
        ;

      return methods.Single();
    }

    public static string GetMemberName(Expression expression)
    {
      UnaryExpression unaryExpression = expression as UnaryExpression;
      MemberExpression memberExpression = unaryExpression == null ? expression as MemberExpression : unaryExpression.Operand as MemberExpression;
      if (memberExpression == null)
        throw new ArgumentException("Expression was not of the form 'x => x.Property or x => x.Field'.");
      return memberExpression.Member.Name;
    }

    public static object GetPropValue(object src, string propName)
    {
      return src.GetType().GetProperty(propName)?.GetValue(src, null);
    }
  }
}
