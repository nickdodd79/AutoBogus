using AutoBogus.Tests.Models;
using AutoBogus.Tests.Models.Complex;
using Xunit;

namespace AutoBogus.FakeItEasy.Tests
{
  public class FakeItEasyBinderFixture
  {
    [Fact]
    public void Should_Create_With_Mocks()
    {
      var binder = new FakeItEasyBinder();

      AutoFaker.Generate<Order>(binder).Should().BePopulatedWithMocks();
    }
  }
}
