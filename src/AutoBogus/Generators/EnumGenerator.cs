namespace AutoBogus.Generators
{
  internal sealed class EnumGenerator<TType>
    : IAutoGenerator
    where TType: struct, System.Enum
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      return context.Faker.Random.Enum<TType>();
    }
  }
}
