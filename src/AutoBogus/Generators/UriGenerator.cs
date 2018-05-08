using System;

namespace AutoBogus.Generators
{
  internal sealed class UriGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      var url = context.Faker.Internet.Url();
      return new Uri(url);
    }
  }
}
