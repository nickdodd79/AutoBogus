using AutoBogus.Conventions.Generators;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus.Conventions
{
  internal sealed class AutoGeneratorConventionsOverride
    : AutoGeneratorOverride
  {
    internal AutoGeneratorConventionsOverride()
    {
      Generators = new List<IAutoConventionGenerator>
      {
        new FirstNameGenerator(),
        new LastNameGenerator(),
        new FullNameGenerator(),
        new EmailGenerator()
      };
    }

    private IEnumerable<IAutoConventionGenerator> Generators { get; }

    public override bool CanOverride(AutoGenerateContext context)
    {
      return Generators.Any(g => g.CanGenerate(context));
    }

    public override void Generate(AutoGenerateOverrideContext context)
    {
      base.Generate(context);

      // Find the convention generator and populate the instance
      var generator = Generators.FirstOrDefault(g => g.CanGenerate(context.GenerateContext));

      if (generator != null)
      {
        context.Instance = generator.Generate(context.GenerateContext);
      } 
    }
  }
}
