using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Serialization;
using Bogus;

namespace AutoBogus.Template
{
  public static class TemplateExtensions
  {
    /// <summary>
    /// Generate 
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    /// <param name=""></param>
    /// <param name="template"></param>
    /// <returns></returns>
    public static List<TType> GenerateWithTemplate<TType>(this AutoFaker<TType> src, string template) where TType : class
    {
      var templator = new Templator<TType>(src);

      var result = templator.GenerateFromTemplate(template);

      return result;

    }

    
    /// <summary>
    /// Will autonumber the identity property
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="property"></param>
    /// <returns></returns>
    public static AutoFaker<TType> Identity<TType, TProperty>(this AutoFaker<TType> src, Expression<Func<TType, TProperty>> property) where TType : class
    {
      var rule = new FakerRule<TType, TProperty>
      {
        Property = property,
        Setter = f =>
        {
          var genericType = typeof(TProperty);
          //var specificType = genericType.MakeGenericType(typeof(TProperty), property);
          var castMethod = typeof(TemplateExtensions).GetMethod("Cast")!.MakeGenericMethod(new Type[] { genericType });
          var castedObject = castMethod.Invoke(null, new object[] { f.UniqueIndex });
          return (TProperty)castedObject!;
        }
      };

      src.RegisterRule(rule);

      return src;
    }

    /// <summary>
    /// Tells the generator not to generate a value, but to use the default value for the type
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <typeparam name="TType"></typeparam>
    /// <param name="property"></param>
    /// <returns></returns>
    public static AutoFaker<TType> Ignore<TType, TProperty>(this AutoFaker<TType> src,
      Expression<Func<TType, TProperty>> property) where TType : class
    {
      //if we ignore we will get the default value for the type
      var defaultObj = Activator.CreateInstance<TType>();

      var prop = typeof(TType).GetProperty(ReflectionHelper.GetMemberName(property.Body), BindingFlags.Public | BindingFlags.Instance);

      var valueOfProperty = (TProperty) prop!.GetValue(defaultObj)!;

      var setter = new Func<Faker, TProperty>(f => valueOfProperty);

      var rule = new FakerRule<TType, TProperty>
      {
        Property = property,
        Setter = setter
      };

      src.RegisterRule(rule);

      return src;
    }


    public static void RegisterRule<TType>(this AutoFaker<TType> faker, FakerRule<TType> fakerRule) where TType : class
    {
      //dynamically cast object to correct type
      var genericRuleType = typeof(FakerRule<,>);
      var specificRuleType = genericRuleType.MakeGenericType(typeof(TType), fakerRule.PropertyType);
      var castMethod = typeof(TemplateExtensions).GetMethod("Cast")!.MakeGenericMethod(new Type[] {specificRuleType});
      var castedObject = castMethod.Invoke(null, new object[] {fakerRule});

      //dynamically call the RuleFor method on faker object
      var ruleForMethod = ReflectionHelper.GetMethod(faker.GetType(), "RuleFor", new Type[] {fakerRule.PropertyType},
        new Type[] {ReflectionHelper.GetPropType(castedObject!, "Property"), ReflectionHelper.GetPropType(castedObject!, "Setter")});
      ruleForMethod.Invoke(faker,
        new[] {ReflectionHelper.GetPropValue(castedObject!, "Property"), ReflectionHelper.GetPropValue(castedObject!, "Setter")});
    }

    public static TCast Cast<TCast>(object o)
    {
      return (TCast)o;
    }

    public abstract class FakerRule<T>
    {
      public abstract Type PropertyType { get; }

    }

    public class FakerRule<T, TProperty> : FakerRule<T>
    {
      public Expression<Func<T, TProperty>>? Property { get; set; }
      public Func<Faker, TProperty>? Setter { get; set; }
      public override Type PropertyType => typeof(TProperty);
    }

  }

}
