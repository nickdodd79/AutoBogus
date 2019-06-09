namespace AutoBogus.Conventions
{
  /// <summary>
  /// A class for configuring conventions for a generator.
  /// </summary>
  public sealed class AutoConventionGeneratorConfig
  {
    internal AutoConventionGeneratorConfig()
    {
      Enabled = true;
      AlwaysGenerate = true;
    }

    /// <summary>
    /// Whether the generator is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Whether values should always be generated, even is already assigned.
    /// </summary>
    public bool AlwaysGenerate { get; set; }
  }
}
