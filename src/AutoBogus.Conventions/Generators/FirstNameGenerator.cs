using System.Collections.Generic;

namespace AutoBogus.Conventions.Generators
{
  internal sealed class FirstNameGenerator
    : AutoConventionByGenerateName<string>
  {
    protected override IEnumerable<string> GenerateNames => new[]
    {
      "FirstName",
      "GivenName",
      "ChristianName",
      "BaptismName",
      "BaptismalName",
      "Forename"
    };

    protected override object Generate(AutoGenerateContext context)
    {
      return context.Faker.Name.FirstName();
    }
  }
}
