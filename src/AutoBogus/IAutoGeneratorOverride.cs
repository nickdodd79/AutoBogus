using System;

namespace AutoBogus
{
  /// <summary>
  /// An interface for overriding generate requests.
  /// </summary>
  public interface IAutoGeneratorOverride
    : IAutoGenerator
  {
    /// <summary>
    /// Determines whether a generate request can be overridden for a type.
    /// </summary>
    /// <param name="type">The <see cref="System.Type"/> being generated.</param>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance.</param>
    /// <returns>true if the generate reqest can be overridden; otherwise false.</returns>
    bool CanOverride(Type type, AutoGenerateContext context);
  }
}
