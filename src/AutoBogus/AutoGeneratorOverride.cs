using System;

namespace AutoBogus
{
  internal sealed class AutoGeneratorOverride<TType>
    : IAutoGenerator
  {
    internal AutoGeneratorOverride(Func<AutoGeneratorOverrideContext, TType> generator)
    {
      Generator = generator ?? throw new ArgumentNullException(nameof(generator));
    }

    private Func<AutoGeneratorOverrideContext, TType> Generator { get; }

    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      var overrideContext = new AutoGeneratorOverrideContext(context);
      var value = Generator.Invoke(overrideContext);

      // Only populate the generated instance if the populate flah is true
      if (overrideContext.Populate)
      {
        context.Binder.PopulateInstance<TType>(value, context);
      }

      return value;
    }
  }
}
