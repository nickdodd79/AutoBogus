using Bogus;

namespace AutoBogus.Conventions
{
  internal sealed class AutoConventionContext
  {
    internal AutoConventionContext(AutoGenerateOverrideContext context)
    {
      GenerateContext = context.GenerateContext;
      Faker = context.Faker;
    }

    internal object Instance { get; set; }
    
    internal AutoGenerateContext GenerateContext { get; }
    internal Faker Faker { get; }
  }
}
