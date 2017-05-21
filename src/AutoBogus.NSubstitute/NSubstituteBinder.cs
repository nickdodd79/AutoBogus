using NSubstitute;
using System.Reflection;

namespace AutoBogus.NSubstitute
{
  public sealed class NSubstituteBinder
    : AutoBinder
  {
    public override TType CreateInstance<TType>(AutoGenerateContext context)
    {
      var type = typeof(TType);
      var typeInfo = type.GetTypeInfo();

      if (typeInfo.IsInterface || typeInfo.IsAbstract)
      {
        return (TType) Substitute.For(new[] { type }, new object[0]);
      }

      return base.CreateInstance<TType>(context);
    }
  }
}
