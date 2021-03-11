using System;
using System.Collections.Generic;

namespace AutoBogus.Generators
{
  internal sealed class ListGenerator<TType>
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      IList<TType> list;

      try
      {
        list = (IList<TType>)Activator.CreateInstance(context.GenerateType);
      }
      catch
      {
        list = new List<TType>();
      }

      var items = context.GenerateMany<TType>();

      foreach (var item in items)
      {
        list.Add(item);
      }

      return list;
    }
  }
}
