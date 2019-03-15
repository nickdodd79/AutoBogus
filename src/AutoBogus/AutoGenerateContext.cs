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
    internal AutoGenerateContext(Faker faker, IEnumerable<string> ruleSets, IAutoBinder binder)
    {
      Faker = faker;
      RuleSets = ruleSets;
      Binder = binder;

      Types = new Stack<Type>();
    }

    /// <summary>
    /// The underlying <see cref="Bogus.Faker"/> instance used to generate random values.
    /// </summary>
    public Faker Faker { get; }

    /// <summary>
    /// The requested rule sets provided for the generate request.
    /// </summary>
    public IEnumerable<string> RuleSets { get; }

    internal Stack<Type> Types { get; }
    internal IAutoBinder Binder { get; }

    /// <summary>
    /// Creates an instance of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <returns>An instance of <typeparamref name="TType"/>.</returns>
    public TType Generate<TType>()
    {
      var generator = AutoGeneratorFactory.GetGenerator<TType>(this);
      return (TType)generator.Generate(this);
    }

    /// <summary>
    /// Creates a collection of instances of type <typeparamref name="TType"/>.
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
    /// Creates a collection of unique instances of type <typeparamref name="TType"/>.
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
