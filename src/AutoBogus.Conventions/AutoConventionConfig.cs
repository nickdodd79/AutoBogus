namespace AutoBogus.Conventions
{
  /// <summary>
  /// A class used to configure conventions for a generate request.
  /// </summary>
  public sealed partial class AutoConventionConfig
  {
    internal AutoConventionConfig()
    {
      AlwaysGenerate = true;
    }

    /// <summary>
    /// Whether all values should always be generated, even is already assigned.
    /// </summary>
    public bool AlwaysGenerate { get; set; }
  }
}
