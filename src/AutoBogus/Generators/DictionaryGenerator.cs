using System;
using System.Collections.Generic;

namespace AutoBogus.Generators
{
  internal sealed class DictionaryGenerator<TKey, TValue>
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      var items = (IDictionary<TKey, TValue>)Activator.CreateInstance(context.GenerateType);

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
