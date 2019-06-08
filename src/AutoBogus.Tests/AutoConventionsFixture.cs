using AutoBogus.Conventions;
using FluentAssertions;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoConventionsFixture
  {
    private class TestClass
    {
      public string FirstName { get; set; }
      public string Surname { get; set; }
      public string FullName { get; set; }
      public string Email { get; set; }
    }

    private IAutoFaker _faker;

    public AutoConventionsFixture()
    {
      _faker = AutoFaker.Create(builder =>
      {
        builder.WithConventions();
      });
    }

    [Fact]
    public void Should_Apply_Conventions()
    {
      var instance = _faker.Generate<TestClass>();
      instance.Email.Should().Contain("@");
    }
  }
}
