using Bogus;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoGenerateContextExtensionsFixture
  {
    private Faker _faker;
    private IEnumerable<string> _ruleSets;
    private AutoBinder _binder;
    private AutoGenerateContext _context;

    public AutoGenerateContextExtensionsFixture()
    {
      _faker = new Faker();
      _ruleSets = Enumerable.Empty<string>();
      _binder = new AutoBinder();
    }

    public class GenerateMany_Internal
      : AutoGenerateContextExtensionsFixture
    {
      private int _value;
      private List<int> _items;

      public GenerateMany_Internal()
      {
        _value = 1;
        _items = new List<int> { _value };
        _context = new AutoGenerateContext(_faker, _binder)
        {
          RuleSets = _ruleSets
        };
      }

      [Fact]
      public void Should_Generate_Duplicates_If_Not_Unique()
      {
        AutoGenerateContextExtensions.GenerateMany(_context, 2, _items, false, 1, () => _value);

        _items.Should().BeEquivalentTo(new[] { 1, 1 });
      }

      [Fact]
      public void Should_Not_Generate_Duplicates_If_Unique()
      {
        AutoGenerateContextExtensions.GenerateMany(_context, 2, _items, true, 1, () =>
        {
          var item = _value;
          _value = 2;

          return item;
        });

        _items.Should().BeEquivalentTo(new[] { 1, 2 });
      }

      [Fact]
      public void Should_Short_Circuit_If_Unique_Attempts_Overflow()
      {
        var attempts = 0;

        AutoGenerateContextExtensions.GenerateMany(_context, 2, _items, true, 1, () =>
        {
          attempts++;
          return _value;
        });

        attempts.Should().Be(AutoFaker.GenerateAttemptsThreshold);

        _items.Should().BeEquivalentTo(new[] { 1 });
      }
    }
  }
}
