using System.Collections.Generic;

namespace AutoBogus
{
  public static class AutoFaker
  {
    public static TType Generate<TType>()
      where TType : class
    {
      var auto = new AutoFaker<TType>();
      return auto.Generate();
    }

    public static IEnumerable<TType> Generate<TType>(int count)
      where TType : class
    {
      var auto = new AutoFaker<TType>();
      return auto.Generate(count);
    }
  }
}
