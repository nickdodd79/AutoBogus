using System;

namespace AutoBogus.Generators
{
  internal sealed class DateTimeOffsetGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      return new System.DateTimeOffset(context.Faker.Date.Recent());
    }
  }
}
