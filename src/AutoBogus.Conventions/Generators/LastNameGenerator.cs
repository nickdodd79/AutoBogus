using System.Collections.Generic;

namespace AutoBogus.Conventions.Generators
{
  internal sealed class LastNameGenerator
    : AutoConventionByGenerateName<string>
  {
    protected override IEnumerable<string> GenerateNames => new[]
    {
      "LastName",
      "FamilyName",
      "Surname",
      "Byname",
      "Cognomen",
      "Matronymic",
      "Metronymic",
      "Patronymic"
    };

    protected override object Generate(AutoGenerateContext context)
    {
      return context.Faker.Name.LastName();
    }
  }
}
