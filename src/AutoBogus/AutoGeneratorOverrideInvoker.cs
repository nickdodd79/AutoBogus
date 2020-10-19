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
      var overrideContext = new AutoGenerateOverrideContext(context);

      foreach (var generatorOverride in Overrides)
      {
        // Check if an initialized instance is needed
        if (generatorOverride.Preinitialize && overrideContext.Instance == null)
        {
          overrideContext.Instance = Generator.Generate(context);
        }

        // Let each override apply updates to the instance
        generatorOverride.Generate(overrideContext);
      }      

      return overrideContext.Instance;
    }
  }
}
