using System.Collections.Generic;

namespace AutoBogus
{
  internal sealed class AutoGeneratorOverrideInvoker
    : IAutoGenerator
  {
    internal AutoGeneratorOverrideInvoker(IAutoGenerator generator, IEnumerable<AutoGeneratorOverride> overrides)
    {
      Generator = generator;
      Overrides = overrides;
    }

    internal IAutoGenerator Generator { get; }
    internal IEnumerable<AutoGeneratorOverride> Overrides { get; }

    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      // Create the override context and generate an initial instance
      var overrideContext = new AutoGenerateOverrideContext(context)
      {
        Instance = Generator.Generate(context)
      };

      // Then allow each override to alter the intial instance
      foreach (var generatorOverride in Overrides)
      {
        generatorOverride.Generate(overrideContext);
      }      

      return overrideContext.Instance;
    }
  }
}
