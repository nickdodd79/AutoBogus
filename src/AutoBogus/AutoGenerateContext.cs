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
    internal AutoGenerateContext(Faker faker, IAutoBinder binder)
    {
      Faker = faker;
      Binder = binder;

      RuleSets = Enumerable.Empty<string>();
      Overrides = Enumerable.Empty<AutoGeneratorOverride>();

      Types = new Stack<Type>();
    }

    /// <summary>
    /// The <see cref="System.Type"/> for the current generate request.
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

    internal Stack<Type> Types { get; }
    internal IAutoBinder Binder { get;}

    internal IEnumerable<AutoGeneratorOverride> Overrides { get; set; }
  }
}
