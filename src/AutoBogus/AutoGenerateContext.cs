using Bogus;
using System;
using System.Collections.Generic;

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

      // Generate the required number of items and ensure the list is unique
      count = (count ?? AutoFaker.DefaultCount);

      while (items.Count < count)
      {
        var item = Generate<TType>();

        // Ensure the generated value is not null (which means the type couldn't be generated)
        // Also ensure the list doesn't already contain the generated value
        if (item != null && !items.Contains(item))
        {
          items.Add(item);
        }
      }

      return items;
    }
  }
}
