using AutoBogus.NSubstitute;
using Xunit.Abstractions;

namespace AutoBogus.Playground
{
  public class ServiceFixture_NSubstitute
    : ServiceFixture
  {
    public ServiceFixture_NSubstitute(ITestOutputHelper output)
      : base(output, new NSubstituteBinder())
    { }
  }
}
