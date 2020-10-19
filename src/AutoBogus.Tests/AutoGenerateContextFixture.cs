using Bogus;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoGenerateContextFixture
  {
    private Faker _faker;
    private IEnumerable<string> _ruleSets;
    private AutoConfig _config;
    private AutoGenerateContext _context;

    public AutoGenerateContextFixture()
    {
      _faker = new Faker();
      _ruleSets = Enumerable.Empty<string>();
      _config = new AutoConfig();
    }

    public class GenerateMany_Internal
      : AutoGenerateContextFixture
    {
      private int _value;
      private List<int> _items;

      public GenerateMany_Internal()
      {
        _value = _faker.Random.Int();
        _items = new List<int> { _value };
        _context = new AutoGenerateContext(_faker, _config)
        {
          RuleSets = _ruleSets
        };
      }

      [Fact]
      public void Should_Generate_Configured_RepeatCount()
      {
        var count = _faker.Random.Int(3, 5);
        var expected = Enumerable.Range(0, count).Select(i => _value).ToList();

        _config.RepeatCount = context => count;

        AutoGenerateContextExtensions.GenerateMany(_context, null, _items, false, 1, () => _value);

        _items.Should().BeEquivalentTo(expected);
      }

      [Fact]
      public void Should_Generate_Duplicates_If_Not_Unique()
      {
        AutoGenerateContextExtensions.GenerateMany(_context, 2, _items, false, 1, () => _value);

        _items.Should().BeEquivalentTo(new[] { _value, _value });
      }

      [Fact]
      public void Should_Not_Generate_Duplicates_If_Unique()
      {
        var first = _value;
        var second = _faker.Random.Int();

        AutoGenerateContextExtensions.GenerateMany(_context, 2, _items, true, 1, () =>
        {
          var item = _value;
          _value = second;

          return item;
        });

        _items.Should().BeEquivalentTo(new[] { first, second });
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

        attempts.Should().Be(AutoConfig.GenerateAttemptsThreshold);

        _items.Should().BeEquivalentTo(new[] { _value });
      }
    }
  }
}
