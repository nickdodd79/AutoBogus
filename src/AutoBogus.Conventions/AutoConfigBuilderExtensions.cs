using System;

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
    /// <param name="configure">A handler for configuring the conventions.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoFakerDefaultConfigBuilder WithConventions(this IAutoFakerDefaultConfigBuilder builder, Action<AutoConventionConfig> configure = null)
    {
      var conventions = CreateConventionsOverride(configure);
      return builder?.WithOverride(conventions);
    }

    /// <summary>
    /// Registers the conventions overrides.
    /// </summary>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <param name="configure">A handler for configuring the conventions.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoGenerateConfigBuilder WithConventions(this IAutoGenerateConfigBuilder builder, Action<AutoConventionConfig> configure = null)
    {
      var conventions = CreateConventionsOverride(configure);
      return builder?.WithOverride(conventions);
    }

    /// <summary>
    /// Registers the conventions overrides.
    /// </summary>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <param name="configure">A handler for configuring the conventions.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoFakerConfigBuilder WithConventions(this IAutoFakerConfigBuilder builder, Action<AutoConventionConfig> configure = null)
    {
      var conventions = CreateConventionsOverride(configure);
      return builder?.WithOverride(conventions);
    }

    private static AutoGeneratorConventionsOverride CreateConventionsOverride(Action<AutoConventionConfig> configure)
    {
      var config = new AutoConventionConfig();
      configure?.Invoke(config);

      return new AutoGeneratorConventionsOverride(config);
    }
  }
}
