using System;
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
    /// <param name="configure">A handler to build the generate request configuration.</param>
    /// <returns>The generated instance.</returns>
    TType Generate<TType>(Action<IAutoGenerateConfigBuilder> configure = null);

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="configure">A handler to build the generate request configuration.</param>
    /// <returns>The generated collection of instances.</returns>
    List<TType> Generate<TType>(int count, Action<IAutoGenerateConfigBuilder> configure = null);

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="configure">A handler to build the generate request configuration.</param>
    /// <returns>The generated instance.</returns>
    TType Generate<TType, TFaker>(Action<IAutoFakerConfigBuilder> configure = null)
      where TType : class
      where TFaker : AutoFaker<TType>;

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="configure">A handler to build the generate request configuration.</param>
    /// <returns>The generated collection of instances.</returns>
    List<TType> Generate<TType, TFaker>(int count, Action<IAutoFakerConfigBuilder> configure = null)
      where TType : class
      where TFaker : AutoFaker<TType>;

    #region Obsolete

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="args">The constructor arguments used to instantiate the faker.</param>
    /// <returns>The generated instance.</returns>
    [Obsolete("Use IAutoFaker.Generate<TType, TFaker>(builder => builder.WithArgs()) instead.")]
    TType Generate<TType, TFaker>(object[] args)
      where TType : class
      where TFaker : AutoFaker<TType>;

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="args">The constructor arguments used to instantiate the faker.</param>
    /// <returns>The generated collection of instances.</returns>
    [Obsolete("Use IAutoFaker.Generate<TType, TFaker>(count, builder => builder.WithArgs()) instead.")]
    List<TType> Generate<TType, TFaker>(int count, object[] args)
      where TType : class
      where TFaker : AutoFaker<TType>;

    #endregion
  }
}

