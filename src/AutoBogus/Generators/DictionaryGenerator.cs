using System;
using System.Collections.Generic;

namespace AutoBogus.Generators
{
  internal sealed class DictionaryGenerator<TKey, TValue>
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      IDictionary<TKey, TValue> items;
      try
      {
        items = (IDictionary<TKey, TValue>)Activator.CreateInstance(context.GenerateType, true);
      }
      catch
      {
        items = new Dictionary<TKey, TValue>();
      }
      
      // Get a list of keys
      var keys = context.GenerateUniqueMany<TKey>();

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
