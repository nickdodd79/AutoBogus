namespace AutoBogus
{
  /// <summary>
  /// A class for overriding generate requests.
  /// </summary>
  public abstract class AutoGeneratorOverride
  {
    /// <summary>
    /// Determines whether a generate request can be overridden.
    /// </summary>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance for the current generate request.</param>
    /// <returns>true if the generate reqest can be overridden; otherwise false.</returns>
    public abstract bool CanOverride(AutoGenerateContext context);

    /// <summary>
    /// Generates an override instance of a given type.
    /// </summary>
    /// <param name="context">The <see cref="AutoGenerateOverrideContext"/> instance for the current generate request.</param>
    public abstract void Generate(AutoGenerateOverrideContext context);
  }
}
