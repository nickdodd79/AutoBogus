using AutoBogus.NSubstitute;
using AutoBogus.Tests.Models;
using AutoBogus.Tests.Models.Complex;
using AutoBogus.Tests.Models.Simple;
using FluentAssertions;
using Xunit;

namespace AutoBogus.Tests
{
  public class NSubstituteBinderFixture
  {
    private IAutoFaker _faker;

    public NSubstituteBinderFixture()
    {
      _faker = AutoFaker.Create(builder =>
      {
        builder.WithBinder<NSubstituteBinder>();
      });
    }

    [Fact]
    public void Should_Create_With_Mocks()
    {
      _faker.Generate<Order>().Should().BeGeneratedWithMocks();
    }

    [Fact]
    public void Should_Create_Interface_Mock()
    {
      _faker.Generate<ITestInterface>().Should().NotBeNull();
    }

    [Fact]
    public void Should_Create_Abstract_Mock()
    {
      _faker.Generate<TestAbstractClass>().Should().NotBeNull();
    }
  }
}
