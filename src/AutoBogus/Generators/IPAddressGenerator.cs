namespace AutoBogus.Generators
{
  internal sealed class IPAddressGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      return context.Faker.Internet.IpAddress();
    }
  }
}
