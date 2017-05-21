using FakeItEasy;
using System.Reflection;

namespace AutoBogus.FakeItEasy
{
  public sealed class FakeItEasyBinder
    : AutoBinder
  {
    public override TType CreateInstance<TType>(AutoGenerateContext context)
    {
      var type = typeof(TType);
      var typeInfo = type.GetTypeInfo();

      if (typeInfo.IsInterface || typeInfo.IsAbstract)
      {
        return A.Fake<TType>();
      }

      return base.CreateInstance<TType>(context);
    }
  }
}
