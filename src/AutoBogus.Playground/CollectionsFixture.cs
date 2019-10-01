using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AutoBogus.Playground
{
  public class CollectionsFixture
  {
    private class Collections
    {
      public ICollection<string> C1 { get; set; }
      public IDictionary<string, string> C2 { get; set; }
      public IEnumerable<string> C3 { get; set; }
      public IList<string> C4 { get; set; }
      public IReadOnlyCollection<string> C5 { get; set; }
      public IReadOnlyDictionary<string, string> C6 { get; set; }
      public IReadOnlyList<string> C7 { get; set; }
      public ISet<string> C8 { get; set; }
    }
    
    [Fact]
    public void Should_Generate_Collections()
    {
      var c1 = AutoFaker.Generate<ICollection<string>>();
      var c2 = AutoFaker.Generate<IDictionary<string, string>>();
      var c3 = AutoFaker.Generate<IEnumerable<string>>();
      var c4 = AutoFaker.Generate<IList<string>>();
      var c5 = AutoFaker.Generate<IReadOnlyCollection<string>>();
      var c6 = AutoFaker.Generate<IReadOnlyDictionary<string, string>>();
      var c7 = AutoFaker.Generate<IReadOnlyList<string>>();
      var c8 = AutoFaker.Generate<ISet<string>>();

      c1.Should().NotBeEmpty();
      c2.Should().NotBeEmpty();
      c3.Should().NotBeEmpty();
      c4.Should().NotBeEmpty();
      c5.Should().NotBeEmpty();
      c6.Should().NotBeEmpty();
      c7.Should().NotBeEmpty();
      c8.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_Generate_Collection_Properties()
    {
      var collections = AutoFaker.Generate<Collections>();

      collections.C1.Should().NotBeEmpty();
      collections.C2.Should().NotBeEmpty();
      collections.C3.Should().NotBeEmpty();
      collections.C4.Should().NotBeEmpty();
      collections.C5.Should().NotBeEmpty();
      collections.C6.Should().NotBeEmpty();
      collections.C7.Should().NotBeEmpty();
      collections.C8.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_Generate_Collection_Properties_With_Rules()
    {
      var faker = new AutoFaker<Collections>()
        .RuleFor(c => c.C1, f => new List<string> { f.Random.Word() })
        .RuleFor(c => c.C2, f => new Dictionary<string, string> { { f.Random.Word(), f.Random.Word() } })
        .RuleFor(c => c.C3, f => new List<string> { f.Random.Word() })
        .RuleFor(c => c.C4, f => new List<string> { f.Random.Word() })
        .RuleFor(c => c.C5, f => new List<string> { f.Random.Word() })
        .RuleFor(c => c.C6, f => new Dictionary<string, string> { { f.Random.Word(), f.Random.Word() } })
        .RuleFor(c => c.C7, f => new List<string> { f.Random.Word() })
        .RuleFor(c => c.C8, f => new HashSet<string> { f.Random.Word() });

      var collections = faker.Generate();

      collections.C1.Should().NotBeEmpty();
      collections.C2.Should().NotBeEmpty();
      collections.C3.Should().NotBeEmpty();
      collections.C4.Should().NotBeEmpty();
      collections.C5.Should().NotBeEmpty();
      collections.C6.Should().NotBeEmpty();
      collections.C7.Should().NotBeEmpty();
      collections.C8.Should().NotBeEmpty();
    }
  }
}
