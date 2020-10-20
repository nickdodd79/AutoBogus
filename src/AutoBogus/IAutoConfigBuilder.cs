using System;
using System.Linq.Expressions;
using Bogus;

namespace AutoBogus
{
  /// <summary>
  /// An interface for building configurations.
  /// </summary>
  /// <typeparam name="TBuilder">The builder type.</typeparam>
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
    /// Registers the number of items to generate for a collection.
    /// </summary>
    /// <param name="count">The repeat count to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithRepeatCount(Func<AutoGenerateContext, int> count);

    /// <summary>
    /// Registers the depth to recursively generate.
    /// </summary>
    /// <param name="depth">The recursive depth to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithRecursiveDepth(int depth);

    /// <summary>
    /// Registers the depth to recursively generate.
    /// </summary>
    /// <param name="depth">The recursive depth to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithRecursiveDepth(Func<AutoGenerateContext, int> depth);

    /// <summary>
    /// Registers a binder instance to use when generating values.
    /// </summary>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithBinder(IAutoBinder binder);

    /// <summary>
    /// Registers the <see cref="Bogus.Faker"/> hub to use in underlying calls to Bogus.
    /// </summary>
    /// <param name="fakerHub">The <see cref="Bogus.Faker"/> instance to use as the hub.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithFakerHub(Faker fakerHub);

    /// <summary>
    /// Registers a type to skip when generating values.
    /// </summary>
    /// <param name="type">The type to skip.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithSkip(Type type);

    /// <summary>
    /// Registers a member to skip for a given type when generating values.
    /// </summary>
    /// <typeparam name="TType">The parent type containing the member.</typeparam>
    /// <param name="memberName">The name of the member to skip.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithSkip<TType>(string memberName);

    /// <summary>
    /// Registers an override instance to use when generating values.
    /// </summary>
    /// <param name="generatorOverride">The <see cref="AutoGeneratorOverride"/> instance to use.</param>
    /// <returns>The current configuration builder instance.</returns>
    TBuilder WithOverride(AutoGeneratorOverride generatorOverride);
  }
}
