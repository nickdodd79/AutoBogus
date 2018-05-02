using AutoBogus.Util;
using FakeItEasy;

namespace AutoBogus.FakeItEasy
{
  /// <summary>
  /// A class that enables FakeItEasy binding for interface and abstract types.
  /// </summary>
  public sealed class FakeItEasyBinder
    : AutoBinder
  {
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
        return A.Fake<TType>();
      }

      return base.CreateInstance<TType>(context);
    }
  }
}
