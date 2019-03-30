using AutoBogus.Tests.Models.Simple;
using FluentAssertions;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoGeneratorOverridesFixture
  {
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
