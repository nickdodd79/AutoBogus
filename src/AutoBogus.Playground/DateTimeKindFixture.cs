using FluentAssertions;
using System;
using Xunit;

namespace AutoBogus.Playground
{
  public class DateTimeKindFixture
  {
    private sealed class Obj
    {
      public DateTime Birthday { get; set; }
    }

    [Fact]
    public void Should_ConvertToUtc()
    {
      var obj = AutoFaker.Generate<Obj>(builder =>
      {
        builder.WithDateTimeKind(DateTimeKind.Utc);
      });

      obj.Birthday.Should().Be(obj.Birthday.ToUniversalTime());
    }

    [Fact]
    public void Should_BeLocal()
    {
      var obj = AutoFaker.Generate<Obj>();

      obj.Birthday.Should().Be(obj.Birthday.ToLocalTime());
    }
  }
}
