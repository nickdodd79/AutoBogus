using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AutoBogus.Playground
{
  public class InheritedDictionaryFixture
  {
    public class Obj
    {
      public Guid Id { get; set; }
      public Properties Properties { get; set; }
    }

    public class Properties : Dictionary<Guid, string>
    {
      public Properties()
      { }

      public Properties(IDictionary<Guid, string> dictionary)
        : base(dictionary)
      { }
    }

    [Fact]
    public void Should_Populate_Object()
    {
      var obj = AutoFaker.Generate<Obj>();

      obj.Should().NotBeNull();
      obj.Properties.Should().NotBeNull();
    }
  }
}
