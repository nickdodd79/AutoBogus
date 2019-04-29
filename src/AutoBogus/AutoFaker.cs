using System;
using System.Collections.Generic;

namespace AutoBogus
{
  /// <summary>
  /// A class used to conveniently invoke generate requests.
  /// </summary>
  public sealed class AutoFaker
    : IAutoFaker
  {
    internal static AutoConfig DefaultConfig = new AutoConfig();

    private AutoFaker(AutoConfig config)
    {
      Config = config;
    }

    internal AutoConfig Config { get; }

    TType IAutoFaker.Generate<TType>(Action<IAutoGenerateConfigBuilder> configure)
    {
      var context = CreateContext(configure);
      return context.Generate<TType>();
    }

    List<TType> IAutoFaker.Generate<TType>(int count, Action<IAutoGenerateConfigBuilder> configure)
    {
      var context = CreateContext(configure);
      return context.GenerateMany<TType>(count);
    }

    TType IAutoFaker.Generate<TType, TFaker>(Action<IAutoFakerConfigBuilder> configure)
    {
      var faker = CreateFaker<TType, TFaker>(configure);
      return faker.Generate();
    }

    List<TType> IAutoFaker.Generate<TType, TFaker>(int count, Action<IAutoFakerConfigBuilder> configure)
    {
      var faker = CreateFaker<TType, TFaker>(configure);
      return faker.Generate(count);
    }

    /// <summary>
    /// Configures all faker instances and generate requests.
    /// </summary>
    /// <param name="configure">A handler to build the default faker configuration.</param>
    public static void Configure(Action<IAutoFakerDefaultConfigBuilder> configure)
    {
      var builder = new AutoConfigBuilder(DefaultConfig);
      configure?.Invoke(builder);
    }

    /// <summary>
    /// Creates a configured <see cref="IAutoFaker"/> instance.
    /// </summary>
    /// <param name="configure">A handler to build the faker configuration.</param>
    /// <returns>The configured <see cref="IAutoFaker"/> instance.</returns>
    public static IAutoFaker Create(Action<IAutoGenerateConfigBuilder> configure = null)
    {
      var config = new AutoConfig(DefaultConfig);
      var builder = new AutoConfigBuilder(config);

      configure?.Invoke(builder);

      return new AutoFaker(config);
    }

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <param name="configure">A handler to build the generate request configuration.</param>
    /// <returns>The generated instance.</returns>
    public static TType Generate<TType>(Action<IAutoGenerateConfigBuilder> configure = null)
    {
      var faker = Create(configure);
      return faker.Generate<TType>();
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="configure">A handler to build the generate request configuration.</param>
    /// <returns>The generated collection of instances.</returns>
    public static List<TType> Generate<TType>(int count, Action<IAutoGenerateConfigBuilder> configure = null)
    {
      var faker = Create(configure);
      return faker.Generate<TType>(count);
    }

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="configure">A handler to build the generate request configuration.</param>
    /// <returns>The generated instance.</returns>
    public static TType Generate<TType, TFaker>(Action<IAutoFakerConfigBuilder> configure = null)
      where TType : class
      where TFaker : AutoFaker<TType>
    {
      var faker = Create();
      return faker.Generate<TType, TFaker>(configure);
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="configure">A handler to build the generate request configuration.</param>
    /// <returns>The generated collection of instances.</returns>
    public static List<TType> Generate<TType, TFaker>(int count, Action<IAutoFakerConfigBuilder> configure = null)
      where TType : class
      where TFaker : AutoFaker<TType>
    {
      var faker = Create();
      return faker.Generate<TType, TFaker>(count, configure);
    }

    private AutoGenerateContext CreateContext(Action<IAutoGenerateConfigBuilder> configure)
    {
      var config = new AutoConfig(Config);
      var builder = new AutoConfigBuilder(config);

      configure?.Invoke(builder);

      return new AutoGenerateContext(config);
    }

    private AutoFaker<TType> CreateFaker<TType, TFaker>(Action<IAutoFakerConfigBuilder> configure)
      where TType : class
      where TFaker : AutoFaker<TType>
    {
      // Invoke the config builder
      var config = new AutoConfig(Config);
      var builder = new AutoConfigBuilder(config);

      configure?.Invoke(builder);

      // Dynamically create the faker instance
      var type = typeof(TFaker);
      var faker = (AutoFaker<TType>)Activator.CreateInstance(type, builder.Args);

      faker.Config = builder.Config;

      return faker;
    }

    #region Obsolete Instance

    TType IAutoFaker.Generate<TType, TFaker>(object[] args)
    {
      var faker = CreateFaker<TType, TFaker>(builder =>
      {
        builder.WithArgs(args);
      });

      return faker.Generate();
    }

    List<TType> IAutoFaker.Generate<TType, TFaker>(int count, object[] args)
    {
      var faker = CreateFaker<TType, TFaker>(builder =>
      {
        builder.WithArgs(args);
      });

      return faker.Generate(count);
    }

    #endregion

    #region Obsolete Static    

    /// <summary>
    /// Creates a configured <see cref="IAutoFaker"/> instance.
    /// </summary>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <returns>The configured <see cref="IAutoFaker"/> instance.</returns>
    [Obsolete("Use AutoFaker.Create(builder => builder.WithLocale()) instead.")]
    public static IAutoFaker Create(string locale)
    {
      return Create(builder =>
      {
        builder.WithLocale(locale);
      });
    }

    /// <summary>
    /// Creates a configured <see cref="IAutoFaker"/> instance.
    /// </summary>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use for generate requests.</param>
    /// <returns>The configured <see cref="IAutoFaker"/> instance.</returns>
    [Obsolete("Use AutoFaker.Create(builder => builder.WithBinder()) instead.")]
    public static IAutoFaker Create(IAutoBinder binder)
    {
      return Create(builder =>
      {
        builder.WithBinder(binder);
      });
    }

    /// <summary>
    /// Creates a configured <see cref="IAutoFaker"/> instance.
    /// </summary>
    /// <typeparam name="TBinder">The <see cref="IAutoBinder"/> type of use for generate requests.</typeparam>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <returns>The configured <see cref="IAutoFaker"/> instance.</returns>
    [Obsolete("Use AutoFaker.Create(builder => builder.WithLocale().WithBinder()) instead.")]
    public static IAutoFaker Create<TBinder>(string locale = null)
      where TBinder : IAutoBinder, new()
    {
      return Create(builder =>
      {
        builder
          .WithLocale(locale)
          .WithBinder<TBinder>();
      });
    }

    /// <summary>
    /// Creates a configured <see cref="IAutoFaker"/> instance.
    /// </summary>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use for generate requests.</param>
    /// <returns>The configured <see cref="IAutoFaker"/> instance.</returns>
    [Obsolete("Use AutoFaker.Create(builder => builder.WithLocale().WithBinder()) instead.")]
    public static IAutoFaker Create(string locale, IAutoBinder binder)
    {
      return Create(builder =>
      {
        builder
          .WithLocale(locale)
          .WithBinder(binder);
      });
    }

    /// <summary>
    /// Sets the default binder used for binding generated instances.
    /// </summary>
    /// <typeparam name="TBinder">The binder type to use for generate requests.</typeparam>
    [Obsolete("Use AutoFaker.Configure(builder => builder.WithBinder()) instead.")]
    public static void SetBinder<TBinder>()
      where TBinder : IAutoBinder, new()
    {
      Configure(builder =>
      {
        builder.WithBinder<TBinder>();
      });
    }

    /// <summary>
    /// Sets the default binder used for binding generated instances.
    /// </summary>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use for generate requests.</param>
    [Obsolete("Use AutoFaker.Configure(builder => builder.WithBinder()) instead.")]
    public static void SetBinder(IAutoBinder binder)
    {
      Configure(builder =>
      {
        builder.WithBinder(binder);
      });
    }

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <returns>The generated instance of type <typeparamref name="TType"/>.</returns>
    [Obsolete("Use AutoFaker.Generate<TType>(builder => builder.WithLocale()) instead.")]
    public static TType Generate<TType>(string locale)
    {
      return Generate<TType>(builder =>
      {
        builder.WithLocale(locale);
      });
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <returns>The collection of generated instances of type <typeparamref name="TType"/>.</returns>
    [Obsolete("Use AutoFaker.Generate<TType>(count, builder => builder.WithLocale()) instead.")]
    public static List<TType> Generate<TType>(int count, string locale)
    {
      return Generate<TType>(count, builder =>
      {
        builder.WithLocale(locale);
      });
    }

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="args">The constructor arguments used to instantiate type <typeparamref name="TFaker"/>.</param>
    /// <returns>The generated instance of type <typeparamref name="TType"/>.</returns>
    [Obsolete("Use AutoFaker.Generate<TType, TFaker>(builder => builder.WithArgs()) instead.")]
    public static TType Generate<TType, TFaker>(object[] args)
      where TType : class
      where TFaker : AutoFaker<TType>
    {
      return Generate<TType, TFaker>(builder =>
      {
        builder.WithArgs(args);
      });
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="args">The constructor arguments used to instantiate type <typeparamref name="TFaker"/>.</param>
    /// <returns>The collection of generated instances of type <typeparamref name="TType"/>.</returns>
    [Obsolete("Use AutoFaker.Generate<TType, TFaker>(count, builder => builder.WithArgs()) instead.")]
    public static List<TType> Generate<TType, TFaker>(int count, object[] args)
      where TType : class
      where TFaker : AutoFaker<TType>
    {
      return Generate<TType, TFaker>(count, builder =>
      {
        builder.WithArgs(args);
      });
    }

    #endregion
  }
}

