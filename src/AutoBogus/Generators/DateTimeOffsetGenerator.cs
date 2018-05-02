using System;

namespace AutoBogus.Generators
{
  internal sealed class DateTimeOffsetGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      var dateTime = context.Faker.Date.Recent();
      return new DateTimeOffset(dateTime);
    }
  }
}
