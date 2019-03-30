namespace AutoBogus
{
  /// <summary>
  /// An interface for building configurations for fakers.
  /// </summary>
  public interface IAutoFakerConfigBuilder
    : IAutoConfigBuilder<IAutoFakerConfigBuilder>
  {
    /// <summary>
    /// Registers the args to use when constructing an <see cref="AutoFaker{Type}"/> instance.
    /// </summary>
    /// <param name="args">The args to use for construction.</param>
    /// <returns>The current configuration builder instance.</returns>
    IAutoFakerConfigBuilder WithArgs(params object[] args);
  }
}
