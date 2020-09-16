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
      dynamic obj2 = new ExpandoObject();

      obj1.StringProperty = "";
      obj1.IntProperty = 0;

      obj2.NestedIntProp = 0;

      obj1.NestedProp = obj2;

      var faker1 = new AutoFaker<dynamic>();

      faker1.Populate(obj1);

      string stringProp = obj1.StringProperty;
      int intProperty = obj1.IntProperty;
      int nestedIntProp = obj1.NestedProp.NestedIntProp;

      stringProp.Should().NotBeEmpty();
      intProperty.Should().NotBe(0);
      nestedIntProp.Should().NotBe(0);
    }
  }
}

