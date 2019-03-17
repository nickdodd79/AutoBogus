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
      Overrides = Enumerable.Empty<IAutoGeneratorOverride>();

      Types = new Stack<Type>();
    }

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

    internal IEnumerable<IAutoGeneratorOverride> Overrides { get; set; }

    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <returns>An instance of <typeparamref name="TType"/>.</returns>
    public TType Generate<TType>()
    {
      var generator = AutoGeneratorFactory.GetGenerator<TType>(this);
      return (TType)generator.Generate(this);
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <returns>A collection of instances of <typeparamref name="TType"/>.</returns>
    public List<TType> GenerateMany<TType>(int? count = null)
    {
      var items = new List<TType>();
      GenerateMany(count, items, false);

      return items;
    }

    /// <summary>
    /// Generates a collection of unique instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <param name="count">The number of instances to generate.</param>
    /// <returns>A collection of unique instances of <typeparamref name="TType"/>.</returns>
    public List<TType> GenerateUniqueMany<TType>(int? count = null)
    {
      var items = new List<TType>();
      GenerateMany(count, items, true);

      return items;
    }

    /// <summary>
    /// Populates the provided instance with auto generated values.
    /// </summary>
    /// <typeparam name="TType">The type of instance to populate.</typeparam>
    /// <param name="instance">The instance to populate.</param>
    public void Populate<TType>(TType instance)
    {
      Binder.PopulateInstance<TType>(instance, this);
    }

    internal void GenerateMany<TType>(int? count, List<TType> items, bool unique, int attempt = 1, Func<TType> generate = null)
    {
      // Apply any defaults
      count = count ?? AutoFaker.DefaultCount;
      generate = generate ?? (() => Generate<TType>());

      // Generate a list of items
      var required = count - items.Count;

      for (var index = 0; index < required; index++)
      {
        var item = generate.Invoke();

        // Ensure the generated value is not null (which means the type couldn't be generated)
        if (item != null)
        {
          items.Add(item);
        }
      }

      if (unique)
      {
        // Remove any duplicates and generate more to match the required count
        var filtered = items.Distinct().ToList();
        
        if (filtered.Count < count)
        {
          // To maintain the items reference, clear and reapply the filtered list
          items.Clear();
          items.AddRange(filtered);

          // Only continue to generate more if the attempts threshold is not reached
          if (attempt < AutoFaker.GenerateAttemptsThreshold)
          {
            GenerateMany(count, items, unique, attempt + 1, generate);
          }
        }
      }
    }
  }
}
