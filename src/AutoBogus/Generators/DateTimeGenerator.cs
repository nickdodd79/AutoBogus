namespace AutoBogus.Generators
{
  using System;

  internal sealed class DateTimeGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      return context.Config.DateTimeKind.Invoke(context) == DateTimeKind.Utc
        ? context.Faker.Date.Recent().ToUniversalTime()
        : context.Faker.Date.Recent();
    }
  }
}
