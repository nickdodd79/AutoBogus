using System.Linq;

namespace AutoBogus.Generators
{
  internal sealed class ArrayGenerator<TType>
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      var items = context.GenerateMany<TType>(context);
      return items.ToArray();
    }
  }
}

