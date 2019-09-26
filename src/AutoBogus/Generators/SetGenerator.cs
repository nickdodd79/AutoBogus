using System.Collections.Generic;

namespace AutoBogus.Generators
{
  internal sealed class SetGenerator<TType>
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      var set = new HashSet<TType>();
      var items = context.GenerateMany<TType>();

      foreach (var item in items)
      {
        set.Add(item);
      }

      return set;
    }
  }
}
