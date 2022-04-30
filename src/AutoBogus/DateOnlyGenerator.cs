namespace AutoBogus.Generators
{
#if NET6_0
  internal sealed class DateOnlyGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      return context.Faker.Date.RecentDateOnly();
    }
  }
#endif
}
