namespace AutoBogus.Generators
{
  internal sealed class UShortGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      return context.Faker.Random.UShort();
    }
  }
}
