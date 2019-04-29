using AutoBogus.Conventions.Generators;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus.Conventions
{
  internal sealed class AutoGeneratorConventionsOverride
    : AutoGeneratorOverride
  {
    internal AutoGeneratorConventionsOverride(AutoConventionConfig config)
    {
      Config = config;
      Generators = new List<IAutoConventionGenerator>
      {
        new FirstNameGenerator(),
        new LastNameGenerator(),
        new FullNameGenerator(),
        new EmailGenerator()
      };
    }

    private AutoConventionConfig Config { get; }
    private IEnumerable<IAutoConventionGenerator> Generators { get; }

    public override bool CanOverride(AutoGenerateContext context)
    {
      return Generators.Any(g => g.CanGenerate(context));
    }

    public override void Generate(AutoGenerateOverrideContext context)
    {
      // Find the convention generator and populate the instance
      var generator = Generators.FirstOrDefault(g => g.CanGenerate(context.GenerateContext));

      if (generator != null)
      {
        var conventionContext = new AutoConventionContext(Config, context.Faker)
        {
          Instance = context.Instance
        };

        context.Instance = generator.Generate(conventionContext);
      } 
    }
  }
}
