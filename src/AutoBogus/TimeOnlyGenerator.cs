namespace AutoBogus.Generators
{
#if NET6_0
  internal sealed class TimeOnlyGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      return context.Faker.Date.RecentTimeOnly();
    }
  }
#endif
}
