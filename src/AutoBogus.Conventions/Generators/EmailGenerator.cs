using System.Collections.Generic;

namespace AutoBogus.Conventions.Generators
{
  internal sealed class EmailGenerator
    : AutoConventionByGenerateName<string>
  {
    protected override IEnumerable<string> GenerateNames => new[]
    {
      "Email",
      "EmailAddress"
    };

    protected override object Generate(AutoGenerateContext context)
    {
      return context.Faker.Internet.Email();
    }
  }
}
