using System.Collections.Generic;

namespace AutoBogus.Conventions.Generators
{
  internal sealed class FullNameGenerator
    : AutoConventionByGenerateName<string>
  {
    protected override IEnumerable<string> GenerateNames => new[]
    {
      "FullName",
      "Name"
    };
       
    protected override object Generate(AutoGenerateContext context)
    {
      return context.Faker.Name.FullName();
    }
  }
}
