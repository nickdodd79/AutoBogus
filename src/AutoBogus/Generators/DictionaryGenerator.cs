using System;
using System.Collections.Generic;

namespace AutoBogus.Generators
{
  internal sealed class DictionaryGenerator<TKey, TValue>
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      // Create an instance of a dictionary (public and non-public)
      IDictionary<TKey, TValue> items;
      try
      {
        items = (IDictionary<TKey, TValue>)Activator.CreateInstance(context.GenerateType, true);
      }
      catch
      {
        items = new Dictionary<TKey, TValue>();
      }

      // Use the configured IEqualityComparer to generate the unique keys
      var comparer = items is Dictionary<TKey, TValue> dictionary ? dictionary.Comparer : null;

      // Get a list of keys
      var keys = context.GenerateUniqueMany<TKey>(comparer: comparer);

      foreach (var key in keys)
      {
        // Get a matching value for the current key and add to the dictionary
        var value = context.Generate<TValue>();

        if (value != null)
        {
          items.Add(key, value);
        }
      }

      return items;
    }
  }
}
