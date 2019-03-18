using AutoBogus.Conventions.Generators;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus.Conventions
{
  public sealed class AutoGeneratorConventionsOverride
    : AutoGeneratorOverride
  {
    public AutoGeneratorConventionsOverride()
    {
      Generators = new List<IAutoConventionGenerator>
      {
        new FirstNameGenerator(),
        new LastNameGenerator(),
        new FullNameGenerator()
      };
    }

    private IEnumerable<IAutoConventionGenerator> Generators { get; }

    public override bool CanOverride(AutoGenerateContext context)
    {
      return Generators.Any(g => g.CanGenerate(context));
    }

    public override void Generate(AutoGenerateOverrideContext context)
    {
      var generator = Generators.FirstOrDefault(g => g.CanGenerate(context.GenerateContext)); 

      context.Instance = generator == null 
        ? ResolvedGenerator.Generate(context.GenerateContext)
        : context.Instance = generator.Generate(context.GenerateContext);
    }
  }
}
