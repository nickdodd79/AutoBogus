namespace AutoBogus.Conventions
{
  /// <summary>
  /// A class extending the config builder interfaces.
  /// </summary>
  public static class AutoConfigBuilderExtensions
  {
    /// <summary>
    /// Registers the conventions overrides.
    /// </summary>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoFakerDefaultConfigBuilder WithConventions(this IAutoFakerDefaultConfigBuilder builder)
    {
      var conventions = CreateConventionsOverride();
      return builder?.WithOverride(conventions);
    }

    /// <summary>
    /// Registers the conventions overrides.
    /// </summary>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoGenerateConfigBuilder WithConventions(this IAutoGenerateConfigBuilder builder)
    {
      var conventions = CreateConventionsOverride();
      return builder?.WithOverride(conventions);
    }

    /// <summary>
    /// Registers the conventions overrides.
    /// </summary>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoFakerConfigBuilder WithConventions(this IAutoFakerConfigBuilder builder)
    {
      var conventions = CreateConventionsOverride();
      return builder?.WithOverride(conventions);
    }

    private static AutoGeneratorConventionsOverride CreateConventionsOverride()
    {
      return new AutoGeneratorConventionsOverride();
    }
  }
}
