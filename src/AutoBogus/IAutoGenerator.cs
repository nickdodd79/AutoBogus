namespace AutoBogus
{
  /// <summary>
  /// An interface for auto generating instances.
  /// </summary>
  public interface IAutoGenerator
  {
    /// <summary>
    /// Generates an instance based on an <see cref="AutoGenerateContext"/> instance.
    /// </summary>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance.</param>
    /// <returns>The generated instance.</returns>
    object Generate(AutoGenerateContext context);
  }
}
