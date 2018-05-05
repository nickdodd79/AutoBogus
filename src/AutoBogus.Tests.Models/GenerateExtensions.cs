using FluentAssertions;
using FluentAssertions.Primitives;

namespace AutoBogus.Tests.Models
{
  public static class GenerateExtensions
  {
    public static AndConstraint<object> BeGenerated(this ObjectAssertions assertions)
    {
      var should = new GenerateAssertions(assertions.Subject);
      return should.BeGenerated();
    }

    public static AndConstraint<object> BeGeneratedWithMocks(this ObjectAssertions assertions)
    {
      var should = new GenerateAssertions(assertions.Subject);
      return should.BeGeneratedWithMocks();
    }
    
    public static AndConstraint<object> BeGeneratedWithoutMocks(this ObjectAssertions assertions)
    {
      var should = new GenerateAssertions(assertions.Subject);
      return should.BeGeneratedWithoutMocks();
    }

    public static AndConstraint<object> NotBeGenerated(this ObjectAssertions assertions)
    {
      var should = new GenerateAssertions(assertions.Subject);
      return should.NotBeGenerated();
    }
  }
}
