using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus
{
  /// <summary>
  /// A class that provides context for a generate request.
  /// </summary>
  public sealed class AutoGenerateContext
  {
    internal AutoGenerateContext(AutoConfig config)
      : this(config.FakerHub, config)
    { }

    internal AutoGenerateContext(Faker faker, AutoConfig config)
    {
      Faker = faker ?? new Faker(config.Locale);
      Config = config;

      TypesStack = new Stack<Type>();

      RuleSets = Enumerable.Empty<string>();
    }

    internal AutoConfig Config { get; }
    internal Stack<Type> TypesStack { get; }

    internal object Instance { get; set; }

    /// <summary>
    /// The type associated with the current generate request.
    /// </summary>
    public Type GenerateType { get; internal set; }

    /// <summary>
    /// The name associated with the current generate request.
    /// </summary>
    public string GenerateName { get; internal set; }

    /// <summary>
    /// The underlying <see cref="Bogus.Faker"/> instance used to generate random values.
    /// </summary>
    public Faker Faker { get; }

    /// <summary>
    /// The requested rule sets provided for the generate request.
    /// </summary>
    public IEnumerable<string> RuleSets { get; internal set; }

    internal IAutoBinder Binder => Config.Binder;
    internal IEnumerable<AutoGeneratorOverride> Overrides => Config.Overrides;
  }
}
