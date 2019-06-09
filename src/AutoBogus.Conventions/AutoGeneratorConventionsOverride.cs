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
      var generators = new List<IAutoConventionGenerator>();
      generators.AddRange(ByNameGeneratorRegistry.Generators);

      Config = config;
      Generators = generators;
    }

    private AutoConventionConfig Config { get; }
    private List<IAutoConventionGenerator> Generators { get; }

    public override bool CanOverride(AutoGenerateContext context)
    {
      var generator = GetGenerator(context);
      return generator != null;
    }

    public override void Generate(AutoGenerateOverrideContext context)
    {
      var generator = GetGenerator(context.GenerateContext);

      if (generator != null)
      {
        var conventionContext = new AutoConventionContext(Config, context)
        {
          Instance = context.Instance
        };

        context.Instance = generator.Generate(conventionContext);
      } 
    }

    private IAutoConventionGenerator GetGenerator(AutoGenerateContext context)
    {
      return Generators.FirstOrDefault(g => g.Enabled(Config) && g.CanGenerate(context));
    }
  }
}
