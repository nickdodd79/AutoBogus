using AutoBogus.Moq;
using Xunit.Abstractions;

namespace AutoBogus.Playground
{
  public class ServiceFixture_Moq
    : ServiceFixture
  {
    public ServiceFixture_Moq(ITestOutputHelper output)
      : base(output, new MoqBinder())
    { }
  }
}
