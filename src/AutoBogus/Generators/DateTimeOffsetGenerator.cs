using System;

namespace AutoBogus.Generators
{
  internal sealed class DateTimeOffsetGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      var dateTime = context.Config.DateTimeKind.Invoke(context) == DateTimeKind.Utc
        ? context.Faker.Date.Recent().ToUniversalTime()
        : context.Faker.Date.Recent();
      return new DateTimeOffset(dateTime);
    }
  }
}
