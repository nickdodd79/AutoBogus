using FluentAssertions;
using System;
using Xunit;

namespace AutoBogus.Playground
{
  public class OverridesFixture
  {
    private sealed class Obj
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public Exception Exception { get; set; }
    }

    [Fact]
    public void Should_Override()
    {
      var name = AutoFaker.Generate<string>();
      var ex = new Exception();
      var obj = AutoFaker.Generate<Obj>(builder =>
      {
        builder
          .WithOverride<Obj, string>(model => model.Name, context => name)
          .WithOverride(context => ex);
      });

      obj.Name.Should().Be(name);
      obj.Exception.Should().Be(ex);
    }
  }
}
