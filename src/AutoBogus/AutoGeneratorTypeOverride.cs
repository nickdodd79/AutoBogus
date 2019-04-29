using System;

namespace AutoBogus
{
  internal sealed class AutoGeneratorTypeOverride<TType>
    : AutoGeneratorOverride
  {
    internal AutoGeneratorTypeOverride(Func<AutoGenerateOverrideContext, TType> generator)
    {
      Type = typeof(TType);
      Generator = generator ?? throw new ArgumentNullException(nameof(generator));
    }

    private Type Type { get; }
    private Func<AutoGenerateOverrideContext, TType> Generator { get; }

    public override bool CanOverride(AutoGenerateContext context)
    {
      return context.GenerateType == Type;
    }

    public override void Generate(AutoGenerateOverrideContext context)
    {
      context.Instance = Generator.Invoke(context);
    }
  }
}
