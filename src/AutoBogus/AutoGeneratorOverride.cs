namespace AutoBogus
{
  /// <summary>
  /// An class for overriding generate requests.
  /// </summary>
  public abstract class AutoGeneratorOverride
    : IAutoGenerator
  {
    internal IAutoGenerator ResolvedGenerator { get; set; }

    /// <summary>
    /// Determines whether a generate request can be overridden based on an <see cref="AutoGenerateContext"/> instance.
    /// </summary>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance.</param>
    /// <returns>true if the generate reqest can be overridden; otherwise false.</returns>
    public abstract bool CanOverride(AutoGenerateContext context);

    /// <summary>
    /// Generates an override instance for a given type.
    /// </summary>
    /// <param name="context">The <see cref="AutoGenerateOverrideContext"/> instance.</param>
    public virtual void Generate(AutoGenerateOverrideContext context)
    {
      context.Instance = ResolvedGenerator.Generate(context.GenerateContext);
    }

    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      var overrideContext = new AutoGenerateOverrideContext(context);
      Generate(overrideContext);

      return overrideContext.Instance;
    }
  }
}
