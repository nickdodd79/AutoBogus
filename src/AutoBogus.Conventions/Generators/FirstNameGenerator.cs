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

    protected override object Generate(AutoConventionContext context)
    {
      return GenerateUsing(context, () => context.Faker.Name.FirstName());
    }
  }
}
