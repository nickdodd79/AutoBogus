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

    protected override object Generate(AutoConventionContext context)
    {
      return GenerateUsing(context, () => context.Faker.Name.LastName());
    }
  }
}
