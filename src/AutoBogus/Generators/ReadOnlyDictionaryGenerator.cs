using System;
using System.Collections.Generic;

using AutoBogus.Util;

namespace AutoBogus.Generators
{
  internal sealed class ReadOnlyDictionaryGenerator<TKey, TValue>
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      IAutoGenerator generator = new DictionaryGenerator<TKey, TValue>();

      Type generateType = context.GenerateType;

      if (ReflectionHelper.IsInterface(generateType))
        generateType = typeof(Dictionary<TKey, TValue>);

      // Generate a standard dictionary and create the read only dictionary
      var items = generator.Generate(context) as IDictionary<TKey, TValue>;

#if NET40
      return null;
#else
      return Activator.CreateInstance(generateType, new[] { items });
#endif
    }
  }
}
