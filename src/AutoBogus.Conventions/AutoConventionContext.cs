using Bogus;

namespace AutoBogus.Conventions
{
  internal sealed class AutoConventionContext
  {
    internal AutoConventionContext(AutoConventionConfig config, Faker faker)
    {
      Config = config;
      Faker = faker;
    }

    internal object Instance { get; set; }

    internal AutoConventionConfig Config { get; }
    internal Faker Faker { get; }
  }
}
