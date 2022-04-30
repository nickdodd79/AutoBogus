using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AutoBogus.Playground
{
  public class DateTimeOnlyFixture
  {
#if NET6_0
    private sealed class DateTimeKeeper
    {
      public DateTime Old { get; set; }
      public DateOnly DeprecationDate { get; set; }
      public TimeOnly DeprecationTime { get; set; }
    }

    [Fact]
    public void DateOnlyTimeOnlyTest()
    {
      int seed = 1;

      var faker1 = new AutoFaker<DateTimeKeeper>().UseSeed(seed);
      var faker2 = new AutoFaker<DateTimeKeeper>().UseSeed(seed);
      var faker3 = new AutoFaker<DateTimeKeeper>();
      var entity1 = faker1.Generate();
      var entity2 = faker2.Generate();
      var entity3 = faker3.Generate();

      entity2.DeprecationDate.ToDateTime(TimeOnly.MinValue)
        .Should()
        .BeCloseTo(entity1.DeprecationDate.ToDateTime(TimeOnly.MinValue), TimeSpan.FromMilliseconds(500));

      entity3.DeprecationDate.ToDateTime(TimeOnly.MinValue)
        .Should()
        .NotBeCloseTo(entity2.DeprecationDate.ToDateTime(TimeOnly.MinValue), TimeSpan.FromMilliseconds(500));

      entity2.DeprecationTime.ToTimeSpan()
        .Should()
        .BeCloseTo(entity1.DeprecationTime.ToTimeSpan(), TimeSpan.FromMilliseconds(500));

      entity3.DeprecationTime.ToTimeSpan()
        .Should()
        .NotBeCloseTo(entity2.DeprecationTime.ToTimeSpan(), TimeSpan.FromMilliseconds(500));
    }
#endif
  }
}
