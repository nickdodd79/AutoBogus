using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AutoBogus.Playground
{
  public class InheritedCaseInsensitiveDictionaryFixture
  {
    public class Obj
    {
      public Guid Id { get; set; }
      public Properties Properties { get; set; }
    }

    public class Properties : Dictionary<string, string>
    {
      public Properties() : base(StringComparer.InvariantCultureIgnoreCase)
      { }

      public Properties(IDictionary<string, string> dictionary)
        : base(dictionary, StringComparer.InvariantCultureIgnoreCase)
      { }
    }

    [Fact]
    public void Should_Populate_Object()
    {
      // Override string generation to force a duplicate key error on a case insensitive dictionary
      var keys = new List<string> { "key", "Key", "kEy", "keY" };

      var obj = new AutoFaker<Obj>()
        .Configure(builder => builder.WithOverride(context => context.Faker.PickRandom(keys)))
        .Generate();

      obj.Should().NotBeNull();
      obj.Properties.Should().NotBeNull();
      obj.Properties.Should().HaveCount(1);
    }
  }
}
