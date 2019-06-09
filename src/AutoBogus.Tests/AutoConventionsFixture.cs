using AutoBogus.Conventions;
using FluentAssertions;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoConventionsFixture
  {
    private class TestClass
    {
      public string Email { get; set; }
    }

    private class TestGeneratorOverride
      : AutoGeneratorOverride
    {
      public override bool CanOverride(AutoGenerateContext context)
      {
        return context.GenerateName == "Email";
      }

      public override void Generate(AutoGenerateOverrideContext context)
      {
        context.Instance = "EMAIL";
      }
    }

    private IAutoFaker _faker;

    [Fact]
    public void Should_Apply_Conventions()
    {
      _faker = AutoFaker.Create(builder =>
      {
        builder.WithConventions();
      });

      var instance = _faker.Generate<TestClass>();
      instance.Email.Should().Contain("@");
    }

    [Fact]
    public void Should_Not_Apply_Conventions_For_Disabled_Generator()
    {
      _faker = AutoFaker.Create(builder =>
      {
        builder.WithConventions(c => c.Email.Enabled = false);
      });

      var instance = _faker.Generate<TestClass>();
      instance.Email.Should().NotContain("@");
    }

    [Fact]
    public void Should_Not_Apply_Conventions_When_AlwaysGenerate_Is_False()
    {
      _faker = AutoFaker.Create(builder =>
      {
        builder
          .WithOverride(new TestGeneratorOverride())
          .WithConventions(c => c.AlwaysGenerate = false);
      });

      var instance = _faker.Generate<TestClass>();
      instance.Email.Should().Be("EMAIL");
    }

    [Fact]
    public void Should_Not_Apply_Conventions_When_Generator_AlwaysGenerate_Is_False()
    {
      _faker = AutoFaker.Create(builder =>
      {
        builder
          .WithOverride(new TestGeneratorOverride())
          .WithConventions(c => c.Email.AlwaysGenerate = false);
      });

      var instance = _faker.Generate<TestClass>();
      instance.Email.Should().Be("EMAIL");
    }
  }
}
