using System;

namespace AutoBogus
{
  /// <summary>
  /// A class for overriding generate requests based on a type.
  /// </summary>
  /// <typeparam name="TType">The type of instance to override.</typeparam>
  public sealed class AutoGeneratorTypeOverride<TType>
    : AutoGeneratorOverride
  {
    /// <summary>
    /// Instantiates an instance of the <see cref="AutoGeneratorTypeOverride{TType}"/> class.
    /// </summary>
    /// <param name="generator">A handler used to generate the override instance.</param>
    public AutoGeneratorTypeOverride(Func<AutoGenerateContext, TType> generator)
    {
      Generator = generator ?? throw new ArgumentNullException(nameof(generator));
    }

    private Func<AutoGenerateContext, TType> Generator { get; }

    /// <summary>
    /// Determines whether a generate request can be overridden based on an <see cref="AutoGenerateContext"/> instance.
    /// </summary>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance.</param>
    /// <returns>true if the generate reqest can be overridden; otherwise false.</returns>
    public override bool CanOverride(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(TType);
    }

    /// <summary>
    /// Generates an override instance for a given type.
    /// </summary>
    /// <param name="context">The <see cref="AutoGenerateOverrideContext"/> instance.</param>
    public override void Generate(AutoGenerateOverrideContext context)
    {
      context.Instance = Generator.Invoke(context.GenerateContext);
    }
  }
}
