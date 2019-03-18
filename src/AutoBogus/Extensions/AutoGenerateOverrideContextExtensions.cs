using System.Collections.Generic;

namespace AutoBogus
{
  /// <summary>
  /// A class extending the <see cref="AutoGenerateOverrideContext"/> class.
  /// </summary>
  public static class AutoGenerateOverrideContextExtensions
  {
    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateOverrideContext"/> instance for the current generate request.</param>
    /// <returns>An instance of <typeparamref name="TType"/>.</returns>
    public static TType Generate<TType>(this AutoGenerateOverrideContext context)
    {
      return context.GenerateContext.Generate<TType>();
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateOverrideContext"/> instance for the current generate request.</param>
    /// <param name="count">The number of instances to generate.</param>
    /// <returns>A collection of instances of <typeparamref name="TType"/>.</returns>
    public static List<TType> GenerateMany<TType>(this AutoGenerateOverrideContext context, int? count = null)
    {
      return context.GenerateContext.GenerateMany<TType>(count);
    }

    /// <summary>
    /// Generates a collection of unique instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateOverrideContext"/> instance for the current generate request.</param>
    /// <param name="count">The number of instances to generate.</param>
    /// <returns>A collection of unique instances of <typeparamref name="TType"/>.</returns>
    public static List<TType> GenerateUniqueMany<TType>(this AutoGenerateOverrideContext context, int? count = null)
    {
      return context.GenerateContext.GenerateUniqueMany<TType>(count);
    }

    /// <summary>
    /// Populates the provided instance with auto generated values.
    /// </summary>
    /// <typeparam name="TType">The type of instance to populate.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateOverrideContext"/> instance for the current generate request.</param>
    /// <param name="instance">The instance to populate.</param>
    public static void Populate<TType>(this AutoGenerateOverrideContext context, TType instance)
    {
      context.GenerateContext.Populate(instance);
    }
  }
}
