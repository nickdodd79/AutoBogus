using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoGenerateContextFixture
  {
    private int _value;
    private List<int> _items;
    private AutoGenerateContext _context;

    public AutoGenerateContextFixture()
    {
      _value = 1;
      _items = new List<int> { _value };
      _context = new AutoGenerateContext(null, null, null);
    }

    public class GenerateMany_Internal
      : AutoGenerateContextFixture
    {
      [Fact]
      public void Should_Generate_Duplicates_If_Not_Unique()
      {
        _context.GenerateMany(2, _items, false, 1, () => _value);

        _items.Should().BeEquivalentTo(new[] { 1, 1 });
      }

      [Fact]
      public void Should_Not_Generate_Duplicates_If_Unique()
      {
        _context.GenerateMany(2, _items, true, 1, () =>
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
        
        _context.GenerateMany(2, _items, true, 1, () =>
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
