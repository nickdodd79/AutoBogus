#if NETSTANDARD1_3 || NETSTANDARD2_0
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AutoBogus.Generators
{
  internal sealed class ReadOnlyDictionaryGenerator<TKey, TValue>
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      IAutoGenerator generator = new DictionaryGenerator<TKey, TValue>();

      // Generate a standard dictionary and create the read only dictionary
      var items = generator.Generate(context) as IDictionary<TKey, TValue>;
      return new ReadOnlyDictionary<TKey, TValue>(items);
    }
  }
}
#endif
