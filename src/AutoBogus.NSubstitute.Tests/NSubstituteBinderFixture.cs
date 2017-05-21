using AutoBogus.Tests.Models;
using AutoBogus.Tests.Models.Complex;
using Xunit;

namespace AutoBogus.NSubstitute.Tests
{
  public class NSubstituteBinderFixture
  {
    [Fact]
    public void Should_Create_With_Mocks()
    {
      var binder = new NSubstituteBinder();

      AutoFaker.Generate<Order>(binder).Should().BePopulatedWithMocks();
    }
  }
}
