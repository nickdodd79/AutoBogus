using AutoBogus.Tests.Models;
using AutoBogus.Tests.Models.Complex;
using Xunit;

namespace AutoBogus.Moq.Tests
{
  public class MoqBinderFixture
  {
    [Fact]
    public void Should_Create_With_Mocks()
    {
      var binder = new MoqBinder();

      AutoFaker.Generate<Order>(binder).Should().BePopulatedWithMocks();
    }
  }
}
