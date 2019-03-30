namespace AutoBogus
{
  /// <summary>
  /// An interface for building configurations.
  /// </summary>
  /// <typeparam name="TBuilder"></typeparam>
  public interface IAutoConfigBuilder<TBuilder>
  {
    /// <summary>
    /// Registers the locale to use when generating values.
    /// </summary>
    /// <param name="locale">The locale to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithLocale(string locale);

    /// <summary>
    /// Registers the number of items to generate for a collection.
    /// </summary>
    /// <param name="count">The repeat count to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithRepeatCount(int count);

    /// <summary>
    /// Registers the depth to recursively generate.
    /// </summary>
    /// <param name="depth">The recursive depth to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithRecursiveDepth(int depth);

    /// <summary>
    /// Registers a binder instance to use when generating values.
    /// </summary>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithBinder(IAutoBinder binder);

    /// <summary>
    /// Registers an override instance to use when generating values.
    /// </summary>
    /// <param name="generatorOverride">The <see cref="AutoGeneratorOverride"/> instance to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithOverride(AutoGeneratorOverride generatorOverride);
  }
}
