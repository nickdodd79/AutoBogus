using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus
{
  /// <summary>
  /// A class extending the <see cref="AutoGenerateContext"/> class.
  /// </summary>
  public static class AutoGenerateContextExtensions
  {
    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance for the current generate request.</param>
    /// <returns>The generated instance.</returns>
    public static TType Generate<TType>(this AutoGenerateContext context)
    {
      if (context != null)
      {
        // Set the generate type for the current request
        context.GenerateType = typeof(TType);

        // Get the type generator and return a value
        var generator = AutoGeneratorFactory.GetGenerator(context);
        return (TType)generator.Generate(context);
      }

      return default;
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance for the current generate request.</param>
    /// <param name="count">The number of instances to generate.</param>
    /// <returns>The generated collection of instances.</returns>
    public static List<TType> GenerateMany<TType>(this AutoGenerateContext context, int? count = null)
    {
      var items = new List<TType>();

      if (context != null)
      {
        GenerateMany(context, count, items, false);
      }

      return items;
    }

    /// <summary>
    /// Generates a collection of unique instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <typeparam name="TType">The instance type to generate.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance for the current generate request.</param>
    /// <param name="count">The number of instances to generate.</param>
    /// <returns>The generated collection of unique instances.</returns>
    public static List<TType> GenerateUniqueMany<TType>(this AutoGenerateContext context, int? count = null)
    {
      var items = new List<TType>();

      if (context != null)
      {
        GenerateMany(context, count, items, true);
      }

      return items;
    }
    
    /// <summary>
    /// Populates the provided instance with generated values.
    /// </summary>
    /// <typeparam name="TType">The type of instance to populate.</typeparam>
    /// <param name="context">The <see cref="AutoGenerateContext"/> instance for the current generate request.</param>
    /// <param name="instance">The instance to populate.</param>
    public static void Populate<TType>(this AutoGenerateContext context, TType instance)
    {
      if (context != null)
      {
        context.Binder.PopulateInstance<TType>(instance, context);
      }
    }

    internal static void GenerateMany<TType>(AutoGenerateContext context, int? count, List<TType> items, bool unique, int attempt = 1, Func<TType> generate = null)
    {
      // Apply any defaults
      if (count == null)
      {
        count = context.Config.RepeatCount.Invoke(context);
      }

      generate = generate ?? (() => context.Generate<TType>());

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
          if (attempt < AutoConfig.GenerateAttemptsThreshold)
          {
            GenerateMany(context, count, items, unique, attempt + 1, generate);
          }
        }
      }
    }
  }
}
