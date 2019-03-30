using System;

namespace AutoBogus
{
  /// <summary>
  /// A class extending the config builder interfaces.
  /// </summary>
  public static class AutoConfigBuilderExtensions
  {
    /// <summary>
    /// Registers a binder type to use when generating values.
    /// </summary>
    /// <typeparam name="TBinder">The <see cref="IAutoBinder"/> type to use.</typeparam>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoFakerDefaultConfigBuilder WithBinder<TBinder>(this IAutoFakerDefaultConfigBuilder builder)
      where TBinder : IAutoBinder, new()
    {
      var binder = new TBinder();
      return builder.WithBinder(binder);
    }

    /// <summary>
    /// Registers a binder type to use when generating values.
    /// </summary>
    /// <typeparam name="TBinder">The <see cref="IAutoBinder"/> type to use.</typeparam>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoGenerateConfigBuilder WithBinder<TBinder>(this IAutoGenerateConfigBuilder builder)
      where TBinder : IAutoBinder, new()
    {
      var binder = new TBinder();
      return builder.WithBinder(binder);
    }

    /// <summary>
    /// Registers a binder type to use when generating values.
    /// </summary>
    /// <typeparam name="TBinder">The <see cref="IAutoBinder"/> type to use.</typeparam>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoFakerConfigBuilder WithBinder<TBinder>(this IAutoFakerConfigBuilder builder)
      where TBinder : IAutoBinder, new()
    {
      var binder = new TBinder();
      return builder.WithBinder(binder);
    }

    /// <summary>
    /// Registers an override instance to use when generating values.
    /// </summary>
    /// <typeparam name="TType">The type of instance to override.</typeparam>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <param name="generator">A handler used to generate the override.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoFakerDefaultConfigBuilder WithOverride<TType>(this IAutoFakerDefaultConfigBuilder builder, Func<AutoGenerateOverrideContext, TType> generator)
    {
      var generatorOverride = new AutoGeneratorTypeOverride<TType>(generator);
      return builder.WithOverride(generatorOverride);
    }

    /// <summary>
    /// Registers an override instance to use when generating values.
    /// </summary>
    /// <typeparam name="TType">The type of instance to override.</typeparam>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <param name="generator">A handler used to generate the override.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoGenerateConfigBuilder WithOverride<TType>(this IAutoGenerateConfigBuilder builder, Func<AutoGenerateOverrideContext, TType> generator)
    {
      var generatorOverride = new AutoGeneratorTypeOverride<TType>(generator);
      return builder.WithOverride(generatorOverride);
    }

    /// <summary>
    /// Registers an override instance to use when generating values.
    /// </summary>
    /// <typeparam name="TType">The type of instance to override.</typeparam>
    /// <param name="builder">The current configuration builder instance.</param>
    /// <param name="generator">A handler used to generate the override.</param>
    /// <returns>The current configuration builder instance.</returns>
    public static IAutoFakerConfigBuilder WithOverride<TType>(this IAutoFakerConfigBuilder builder, Func<AutoGenerateOverrideContext, TType> generator)
    {
      var generatorOverride = new AutoGeneratorTypeOverride<TType>(generator);
      return builder.WithOverride(generatorOverride);
    }
  }
}
