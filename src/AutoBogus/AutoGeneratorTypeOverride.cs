using System;

namespace AutoBogus
{
  /// <summary>
  /// A class for overridding generate requests based on a type.
  /// </summary>
  /// <typeparam name="TType">The type of instance to override.</typeparam>
  public sealed class AutoGeneratorTypeOverride<TType>
    : IAutoGeneratorOverride
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

    bool IAutoGeneratorOverride.CanOverride(Type type, AutoGenerateContext context)
    {
      return type == typeof(TType);
    }

    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      return Generator.Invoke(context);
    }
  }
}
