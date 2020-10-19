using AutoBogus.Tests.Models.Simple;
using FluentAssertions;
using System;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoGeneratorOverridesFixture
  {
    private sealed class TestOverride
      : AutoGeneratorOverride
    {
      public TestOverride(bool preinitialize, Action<AutoGenerateOverrideContext> generator)
      {
        Preinitialize = preinitialize;
        Generator = generator;
      }

      public override bool Preinitialize { get; }
      private Action<AutoGenerateOverrideContext> Generator { get; }

      public override bool CanOverride(AutoGenerateContext context)
      {
        return context.GenerateType == typeof(OverrideClass);
      }

      public override void Generate(AutoGenerateOverrideContext context)
      {
        Generator.Invoke(context);
      }
    }

    [Fact]
    public void Should_Initialize_As_Configured()
    {
      AutoFaker.Generate<OverrideClass>(builder =>
      {
        builder
          .WithOverride(new TestOverride(false, context => context.Instance.Should().BeNull()))
          .WithOverride(new TestOverride(true, context => context.Instance.Should().NotBeNull()))
          .WithOverride(new TestOverride(false, context => context.Instance.Should().NotBeNull()));
      });
    }

    [Fact]
    public void Should_Invoke_Type_Override()
    {
      var value = AutoFaker.Generate<int>();
      var result = AutoFaker.Generate<OverrideClass>(builder =>
      {
        builder.WithOverride(context =>
        {
          var instance = context.Instance as OverrideClass;
          var method = typeof(OverrideId).GetMethod("SetValue");

          method.Invoke(instance.Id, new object[] { value });

          return instance;
        });
      });

      result.Id.Value.Should().Be(value);
      result.Name.Should().NotBeNull();
      result.Amounts.Should().NotBeEmpty();
    }
  }
}
