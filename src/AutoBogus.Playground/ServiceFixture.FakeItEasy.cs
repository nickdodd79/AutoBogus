using AutoBogus.FakeItEasy;
using Xunit.Abstractions;

namespace AutoBogus.Playground
{
  public class ServiceFixture_FakeItEasy
    : ServiceFixture
  {
    public ServiceFixture_FakeItEasy(ITestOutputHelper output)
      : base(output, new FakeItEasyBinder())
    { }
  }
}
