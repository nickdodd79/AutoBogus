using AutoBogus.Conventions.Generators;
using System.Linq;

namespace AutoBogus.Conventions
{
  internal sealed class AutoGeneratorConventionsOverride
    : AutoGeneratorOverride
  {
    internal AutoGeneratorConventionsOverride()
    { }
    
    public override bool CanOverride(AutoGenerateContext context)
    {
      return GeneratorRegistry.Generators.Any(g => g.CanGenerate(context));
    }

    public override void Generate(AutoGenerateOverrideContext context)
    {
      // Find the convention generator and populate the instance
      var generator = GeneratorRegistry.Generators.FirstOrDefault(g => g.CanGenerate(context.GenerateContext));

      if (generator != null)
      {
        var conventionContext = new AutoConventionContext(context)
        {
          Instance = context.Instance
        };

        context.Instance = generator.Generate(conventionContext);
      } 
    }
  }
}
