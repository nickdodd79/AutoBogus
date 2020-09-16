using FluentAssertions;
using System.Dynamic;
using Xunit;

namespace AutoBogus.Playground
{
  public class DynamicFixture
  {
    [Fact]
    public void Should_Populate_Dynamic()
    {
      dynamic obj1 = new ExpandoObject();
      obj1.Property1 = "";
      obj1.Property2 = 0;

      var obj2 = new
      {
        Property3 = ""
      };

      var faker1 = new AutoFaker<dynamic>();
      var faker2 = new AutoFaker<object>();

      faker1.Populate(obj1);
      faker2.Populate(obj2);

      string prop1 = obj1.Property1;
      int prop2 = obj1.Property2;
      string prop3 = obj2.Property3;

      prop1.Should().NotBeEmpty();
      prop2.Should().NotBe(0);
      prop3.Should().BeEmpty();
    }
  }
}

