namespace AutoBogus.Generators
{
  internal sealed class VersionGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      return context.Faker.System.Version();
    }
  }
}
