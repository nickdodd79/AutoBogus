using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus
{
  /// <summary>
  /// A class used to conveniently invoke generate requests.
  /// </summary>
  public sealed class AutoFaker
    : IAutoFaker
  {
    internal const int DefaultCount = 3;
    internal const string DefaultLocale = "en";

    internal const int GenerateAttemptsThreshold = 3;

    internal static IAutoBinder DefaultBinder = new AutoBinder();

    private AutoFaker(string locale, IAutoBinder binder)
    {
      Locale = locale;
      Binder = binder;
    }

    internal string Locale { get; private set; }
    internal IAutoBinder Binder { get; private set; }

    TType IAutoFaker.Generate<TType>()
    {
      var context = CreateContext<TType>();
      return context.Generate<TType>();
    }

    List<TType> IAutoFaker.Generate<TType>(int count)
    {
      var context = CreateContext<List<TType>>();
      return context.GenerateMany<TType>(count);
    }

    TType IAutoFaker.Generate<TType, TFaker>(object[] args)
    {
      var faker = CreateFaker<TType, TFaker>(args);
      return faker.Generate();
    }

    List<TType> IAutoFaker.Generate<TType, TFaker>(int count, object[] args)
    {
      var faker = CreateFaker<TType, TFaker>(args);
      return faker.Generate(count);
    }

    private AutoGenerateContext CreateContext<TGenerate>()
    {
      var type = typeof(TGenerate);
      var faker = new Faker(Locale ?? DefaultLocale);
      var ruleSets = Enumerable.Empty<string>();
      var binder = Binder ?? DefaultBinder;

      return new AutoGenerateContext(type, faker, ruleSets, binder);
    }

    #region Create

    /// <summary>
    /// Creates a configured <see cref="IAutoFaker"/> instance.
    /// </summary>
    /// <typeparam name="TBinder">The <see cref="IAutoBinder"/> type of use for generate requests.</typeparam>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <returns>The configured <see cref="IAutoFaker"/> instance.</returns>
    public static IAutoFaker Create<TBinder>(string locale = null)
      where TBinder : IAutoBinder, new()
    {
      var binder = new TBinder();
      return Create(locale, binder);
    }

    /// <summary>
    /// Creates a configured <see cref="IAutoFaker"/> instance.
    /// </summary>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use for generate requests.</param>
    /// <returns>The configured <see cref="IAutoFaker"/> instance.</returns>
    public static IAutoFaker Create(IAutoBinder binder)
    {
      return Create(null, binder);
    }

    /// <summary>
    /// Creates a configured <see cref="IAutoFaker"/> instance.
    /// </summary>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use for generate requests.</param>
    /// <returns>The configured <see cref="IAutoFaker"/> instance.</returns>
    public static IAutoFaker Create(string locale = null, IAutoBinder binder = null)
    {
      return new AutoFaker(locale, binder);
    }

    #endregion

    #region SetBinder

    /// <summary>
    /// Sets the default binder used for binding auto generated instances.
    /// </summary>
    /// <typeparam name="TBinder">The binder type to use for generate requests.</typeparam>
    public static void SetBinder<TBinder>()
      where TBinder : IAutoBinder, new()
    {
      var binder = new TBinder();
      SetBinder(binder);
    }

    /// <summary>
    /// Sets the default binder used for binding auto generated instances.
    /// </summary>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use for generate requests.</param>
    public static void SetBinder(IAutoBinder binder)
    {
      DefaultBinder = binder ?? new AutoBinder();
    }

    #endregion

    #region Generate

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <returns>The generated instance of type <typeparamref name="TType"/>.</returns>
    public static TType Generate<TType>(string locale = null)
    {
      var faker = Create(locale);
      return faker.Generate<TType>();
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <returns>The collection of generated instances of type <typeparamref name="TType"/>.</returns>
    public static List<TType> Generate<TType>(int count, string locale = null)
    {
      var faker = Create(locale);
      return faker.Generate<TType>(count);
    }

    #endregion

    #region Generate_Faker

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="args">The constructor arguments used to instantiate type <typeparamref name="TFaker"/>.</param>
    /// <returns>The generated instance of type <typeparamref name="TType"/>.</returns>
    public static TType Generate<TType, TFaker>(object[] args = null)
      where TType : class
      where TFaker : AutoFaker<TType>
    {
      var faker = CreateFaker<TType, TFaker>(args);
      return faker.Generate();
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/> based on the <typeparamref name="TFaker"/>.
    /// </summary>
    /// <typeparam name="TType">The type of instance to generate.</typeparam>
    /// <typeparam name="TFaker">The type of faker instance to use.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="args">The constructor arguments used to instantiate type <typeparamref name="TFaker"/>.</param>
    /// <returns>The collection of generated instances of type <typeparamref name="TType"/>.</returns>
    public static List<TType> Generate<TType, TFaker>(int count, object[] args = null)
      where TType : class
      where TFaker : AutoFaker<TType>
    {
      var faker = CreateFaker<TType, TFaker>(args);
      return faker.Generate(count);
    }

    #endregion

    private static AutoFaker<TType> CreateFaker<TType, TFaker>(object[] args)
      where TType : class
    {
      var type = typeof(TFaker);
      return (AutoFaker<TType>)Activator.CreateInstance(type, args ?? new object[0]);
    }
  }
}

