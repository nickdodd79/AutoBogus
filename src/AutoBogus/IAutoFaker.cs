using System.Collections.Generic;

namespace AutoBogus
{
  /// <summary>
  /// An interface for invoking generate requests.
  /// </summary>
  public interface IAutoFaker
  {
    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <returns>The generated instance of type <typeparamref name="TType"/>.</returns>
    TType Generate<TType>();

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <returns>The collection of generated instances of type <typeparamref name="TType"/>.</returns>
    List<TType> Generate<TType>(int count);

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="args">The constructor arguments used to instantiate type <typeparamref name="TFaker"/>.</param>
    /// <returns>The generated instance of type <typeparamref name="TType"/>.</returns>
    TType Generate<TType, TFaker>(object[] args = null)
      where TType : class
      where TFaker : AutoFaker<TType>;

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="args">The constructor arguments used to instantiate type <typeparamref name="TFaker"/>.</param>
    /// <returns>The collection of generated instances of type <typeparamref name="TType"/>.</returns>
    List<TType> Generate<TType, TFaker>(int count, object[] args = null)
      where TType : class
      where TFaker : AutoFaker<TType>;
  }
}
