using System;
using System.Collections.Generic;
using System.Text;
using AutoBogus.Template;
using AutoBogus.Tests.Models;
using AutoBogus.Tests.Models.Complex;
using AutoBogus.Tests.Models.Simple;
using FluentAssertions;
using NSubstitute.Core;
using Xunit;

namespace AutoBogus.Tests
{
  public class TemplateFixture
  {
    private sealed class Parent
    {
      public int Id { get; set; }
      public string StringField { get; set; }
      public int IntField { get; set; }
      public int? NullableIntField { get; set; }
      public decimal DecimalField { get; set; }
      public decimal? NullableDecimalField { get; set; }
      public DateTime DateTimeField { get; set; }
      public DateTime? NullableDateTimeField { get; set; }
      public Child Child { get; set; }
      public TestEnum TestEnum { get; set; }


    }

    private enum TestEnum
    {
      Value0, Value1
    }
    private sealed class Child
    {
      public string Name { get; set; }
    }

    public TemplateFixture()
    {

    }

    [Fact]
    public void Should_Handle_Strings()
    {
      var testData =
        " StringField  \r\n" +
        " value1       \r\n" +
        "              \r\n" +
        " $empty$      \r\n" +
        "";

      var faker = new AutoFaker<Parent>();

      var result = faker.GenerateWithTemplate(testData);

      result.Should().HaveCount(3);
      result[0].StringField.Should().Be("value1");
      result[1].StringField.Should().BeNull();
      result[2].StringField.Should().BeEmpty();

    }
    [Fact]
    public void Should_Handle_Int()
    {
      var testData =
        " IntField | NullableIntField  \r\n" +
        " 0        |                   \r\n" +
        " 1        | 0                 \r\n" +
        " 3        | 2                 \r\n" +
        "";

      var faker = new AutoFaker<Parent>();

      var result = faker.GenerateWithTemplate(testData);

      result.Should().HaveCount(3);
      result[0].IntField.Should().Be(0);
      result[0].NullableIntField.Should().BeNull();
      result[1].IntField.Should().Be(1);
      result[1].NullableIntField.Should().Be(0);
      result[2].IntField.Should().Be(3);
      result[2].NullableIntField.Should().Be(2);

    }

    [Fact]
    public void Should_Handle_Decimal()
    {
      var testData =
        " DecimalField | NullableDecimalField  \r\n" +
        " 0            |                      \r\n" +
        " 1.23         | 0.01                 \r\n" +
        " 3.000354     | 2                    \r\n" +
        "";

      var faker = new AutoFaker<Parent>();

      var result = faker.GenerateWithTemplate(testData);

      result.Should().HaveCount(3);
      result[0].DecimalField.Should().Be(0);
      result[0].NullableDecimalField.Should().BeNull();
      result[1].DecimalField.Should().Be(1.23m);
      result[1].NullableDecimalField.Should().Be(0.01m);
      result[2].DecimalField.Should().Be(3.000354m);
      result[2].NullableDecimalField.Should().Be(2);

    }

    
    [Fact]
    public void Should_Handle_Dates()
    {
      var testData =
        " DateTimeField | NullableDateTimeField  \r\n" +
        " 2006-02-28    |                        \r\n" +
        " 2010-03-01    | 2011-04-08             \r\n" +
        "";

      var faker = new AutoFaker<Parent>();

      var result = faker.GenerateWithTemplate(testData);

      result.Should().HaveCount(2);
      result[0].DateTimeField.Should().Be(DateTime.Parse("2006-02-28"));
      result[0].NullableDateTimeField.Should().BeNull();
      result[1].DateTimeField.Should().Be(DateTime.Parse("2010-03-01"));
      result[1].NullableDateTimeField.Should().Be(DateTime.Parse("2011-04-08"));

    }

    [Fact]
    public void Should_Generate_Not_Specified_Fields()
    {
      var testData =
        " StringField  \r\n" +
        " value1       \r\n" +
        "";

      var faker = new AutoFaker<Parent>();
      faker.RuleFor(p => p.IntField, f => 999);

      var result = faker.GenerateWithTemplate(testData);

      result.Should().HaveCount(1);
      result[0].StringField.Should().Be("value1");
      result[0].IntField.Should().Be(999);

      //make sure child got generated
      result.Should().OnlyContain(r => r.Child != null);
    }

    [Fact]
    public void Should_AutoNumber_If_Specified()
    {
      var testData =
        " StringField  \r\n" +
        " value1       \r\n" +
        " value2       \r\n" +
        " value3       \r\n" +
        "";

      var faker = new AutoFaker<Parent>();
      faker.Identity(p => p.Id);

      var result = faker.GenerateWithTemplate(testData);

      result.Should().HaveCount(3);
      result[0].Id.Should().Be(0);
      result[1].Id.Should().Be(1);
      result[2].Id.Should().Be(2);
      
    }

    [Fact]
    public void Should_Ignore_If_Specified()
    {
      var testData =
        " IntField  \r\n" +
        " 10       \r\n" +
        " 11       \r\n" +
        " 12       \r\n" +
        "";

      var faker = new AutoFaker<Parent>();
      faker.Ignore(p => p.StringField);

      var result = faker.GenerateWithTemplate(testData);

      result.Should().HaveCount(3);
      result.Should().OnlyContain(r => r.StringField == null);
      result[0].IntField.Should().Be(10);
      result[1].IntField.Should().Be(11);
      result[2].IntField.Should().Be(12);
        
    }

    [Fact]
    public void Should_Use_Type_Converter_If_Specified()
    {
      var testData =
        " Child  \r\n" +
        " Child1 \r\n" +
        " Child2 \r\n" +
        "        \r\n" +
        "";

      var binder = new TemplateBinder()
        .SetTypeConverter(ChildConverter());

      var faker = new AutoFaker<Parent>(binder);

      var result = faker.GenerateWithTemplate(testData);

      result.Should().HaveCount(3);
      result[0].Child.Name.Should().Be("child1");
      result[1].Child.Name.Should().NotBe("child1"); //noting that in the converted for child2 we'd use a new faker instance
      result[1].Child.Name.Should().NotBeNull();
      result[2].Child.Should().BeNull();

    }

    [Fact]
    public void Should_Treat_Missing_As_Empty_If_Specified()
    {
      var testData =
        " StringField  \r\n" +
        "        \r\n" +
        "";

      var binder = new TemplateBinder()
        .TreatMissingAsEmpty()
        .SetTypeConverter(ChildConverter());

      var faker = new AutoFaker<Parent>(binder);

      var result = faker.GenerateWithTemplate(testData);

      result.Should().HaveCount(1);
      result[0].StringField.Should().BeEmpty();

    }


    private static Func<Type, string, (bool handled, object result)> ChildConverter()
    {
      return (type, value) =>
      {
        if (type == typeof(Child))
        {

          if (string.IsNullOrEmpty(value))
            return (true, null);

          //use a specific type of generation for this value
          Child instance;
          if (value == "Child1")
          {
            var faker = new AutoFaker<Child>()
              .RuleFor(p =>p.Name, f => "child1");
            instance = faker.Generate();
          }
          else
          {
            //use std generation
            instance = AutoFaker.Generate<Child>();
          }

          return (true, instance);
        }

        return (false, null);
      };
    }

  }
}
