using AutoBogus.Util;
using FakeItEasy;
using System;
using System.Reflection;

namespace AutoBogus.FakeItEasy
{
  /// <summary>
  /// A class that enables FakeItEasy binding for interface and abstract types.
  /// </summary>
  public class FakeItEasyBinder
    : AutoBinder
  {
    private static readonly MethodInfo Factory;

    static FakeItEasyBinder()
    {
      // Cache the fake factory method
      var type = typeof(A);
      Factory = type.GetMethod("Fake", new Type[0]);
    }

    /// <summary>
    /// Creates an instance of <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to create.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance for the generate request.</param>
    /// <returns>The created instance of <typeparamref name="TType"/>.</returns>
    public override TType CreateInstance<TType>(AutoGenerateContext context)
    {
      var type = typeof(TType);

      if (ReflectionHelper.IsInterface(type) || ReflectionHelper.IsAbstract(type))
      {
        // Take the cached factory method and make it generic based on the requested type
        // Because this method supports struct and class types, and FakeItEasy only supports class types we need to put this 'hack' into place
        var factory = Factory.MakeGenericMethod(type);
        return (TType)factory.Invoke(null, new object[0]);
      }

      return base.CreateInstance<TType>(context);
    }
  }
}
