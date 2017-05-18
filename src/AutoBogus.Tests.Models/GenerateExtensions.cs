using AutoBogus.Tests.Models.Complex;

namespace AutoBogus.Tests.Models
{
  public static class GenerateExtensions
  {
    public static GenerateAssertions Should(this Order order)
    {
      return new GenerateAssertions(order);
    }
  }
}
