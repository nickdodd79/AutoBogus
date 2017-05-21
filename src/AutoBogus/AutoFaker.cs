using System.Collections.Generic;

namespace AutoBogus
{
  public static class AutoFaker
  {
    public static TType Generate<TType>(IAutoBinder binder = null)
      where TType : class
    {
      var auto = new AutoFaker<TType>(binder);
      return auto.Generate();
    }

    public static IEnumerable<TType> Generate<TType>(int count, IAutoBinder binder = null)
      where TType : class
    {
      var auto = new AutoFaker<TType>(binder);
      return auto.Generate(count);
    }
  }
}
