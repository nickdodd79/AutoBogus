using AutoBogus.Tests.Models;
using AutoBogus.Tests.Models.Complex;
using AutoBogus.Tests.Models.Simple;
using Bogus;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoFakerFixture
  {
    private const string _name = "Generate";
    private static Type _type = typeof(AutoFaker);

    public class SetBinder
      : AutoFakerFixture, IDisposable
    {
      private class TestBinder
        : AutoBinder
      { }

      [Fact]
      public void Should_Set_Binder()
      {
        AutoFaker.SetBinder<TestBinder>();

        AutoFaker.DefaultBinder.Should().BeOfType<TestBinder>();
      }

      [Fact]
      public void Should_Set_Binder_With_Instance()
      {
        var binder = new TestBinder();

        AutoFaker.SetBinder(binder);

        AutoFaker.DefaultBinder.Should().Be(binder);
      }

      public void Dispose()
      {
        // Clear the binder to ensure other tests are not affected - its static
        AutoFaker.SetBinder(null);
      }
    }

    public class Generate
      : AutoFakerFixture
    {
      private static Type _interfaceType = typeof(IAutoFaker);
      private static string _methodName = $"{_interfaceType.FullName}.{_name}";
      private static MethodInfo _generate = _type.GetMethod(_methodName, BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);
      private static MethodInfo _generateMany = _type.GetMethod(_methodName, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(int) }, null); 

      private IAutoFaker _faker;

      public Generate()
      {
        _faker = AutoFaker.Create();
      }

      [Theory]
      [MemberData(nameof(GetTypes))]
      public void Should_Generate_Type(Type type)
      {
        AssertGenerate(type, _generate, _faker);
      }

      [Theory]
      [MemberData(nameof(GetTypes))]
      public void Should_Generate_Many_Types(Type type)
      {
        AssertGenerateMany(type, _generateMany, _faker, AutoFaker.DefaultCount);
      }

      [Fact]
      public void Should_Generate_Complex_Type()
      {
        _faker.Generate<Order>().Should().BeGeneratedWithoutMocks();
      }

      [Fact]
      public void Should_Generate_Many_Complex_Types()
      {
        var instances = _faker.Generate<Order>(AutoFaker.DefaultCount);

        AssertGenerateMany(instances);
      }
    }

    public class Generate_Static
      : AutoFakerFixture
    {
      private static MethodInfo _generate = _type.GetMethod(_name, BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string) }, null);
      private static MethodInfo _generateMany = _type.GetMethod(_name, BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(int), typeof(string) }, null);

      [Theory]
      [MemberData(nameof(GetTypes))]
      public void Should_Generate_Type(Type type)
      {
        AssertGenerate(type, _generate, null, AutoFaker.DefaultLocale);
      }

      [Theory]
      [MemberData(nameof(GetTypes))]
      public void Should_Generate_Many_Types(Type type)
      {
        AssertGenerateMany(type, _generateMany, null, AutoFaker.DefaultCount, AutoFaker.DefaultLocale);
      }

      [Fact]
      public void Should_Generate_Complex_Type()
      {
        AutoFaker.Generate<Order>().Should().BeGeneratedWithoutMocks();
      }

      [Fact]
      public void Should_Generate_Many_Complex_Types()
      {
        var instances = AutoFaker.Generate<Order>(AutoFaker.DefaultCount);

        AssertGenerateMany(instances);
      }
    }

    public class Generate_Faker
      : AutoFakerFixture
    {
      private sealed class OrderFaker
        : AutoFaker<Order>
      { }

      [Fact]
      public void Should_Generate_Complex_Type()
      {
        AutoFaker.Generate<Order, OrderFaker>().Should().BeGeneratedWithoutMocks();
      }

      [Fact]
      public void Should_Generate_Many_Complex_Types()
      {
        var instances = AutoFaker.Generate<Order, OrderFaker>(AutoFaker.DefaultCount);

        AssertGenerateMany(instances);
      }
    }

    public class AutoFaker_T
      : AutoFakerFixture
    {
      private Faker<Order> _order;

      public AutoFaker_T()
      {
        _order = new AutoFaker<Order>();
      }

      [Fact]
      public void Should_Generate_Type()
      {
        _order.Generate().Should().BeGeneratedWithoutMocks();
      }

      [Fact]
      public void Should_Populate_Instance()
      {
        var faker = new Faker();
        var id = faker.Random.Int();
        var calculator = Substitute.For<ICalculator>();
        var order = new Order(id, calculator);

        _order.Populate(order);
          
        order.Should().BeGeneratedWithMocks();
        order.Id.Should().Be(id);
        order.Calculator.Should().Be(calculator);
      }

      [Fact]
      public void Should_Use_Custom_Instantiator()
      {
        var binder = Substitute.For<IAutoBinder>();        
        var order = new AutoFaker<Order>(binder)
          .CustomInstantiator(faker => new Order(default(int), default(ICalculator)))
          .Generate();

        binder.DidNotReceive().CreateInstance<Order>(Arg.Any<AutoGenerateContext>());
      }

      [Fact]
      public void Should_Not_Generate_Rule_Set_Members()
      {
        var code = Guid.NewGuid();
        var order = _order
          .RuleFor(o => o.Code, code)
          .Generate();

        order.Should().BeGeneratedWithoutMocks();
        order.Code.Should().Be(code);
      }

      [Fact]
      public void Should_Not_Generate_If_No_Default_Rule_Set()
      {
        _order.RuleSet("test", rules =>
        {
          // No default constructor so ensure a create action is defined
          // Make the values default so the NotBeGenerated() check passes
          rules.CustomInstantiator(f => new Order(default(int), default(ICalculator)));
        });

        _order.Generate("test").Should().NotBeGenerated();
      }
    }

    public class Behaviors
      : AutoFakerFixture
    {
      [Fact]
      public void Should_Not_Generate_Interface_Type()
      {
        AutoFaker.Generate<ITestInterface>().Should().BeNull();
      }

      [Fact]
      public void Should_Not_Generate_Abstract_Class_Type()
      {
        AutoFaker.Generate<TestAbstractClass>().Should().BeNull();
      }

      [Fact]
      public void Should_Generate_Recursive_Types_To_2_Levels()
      {
        AutoFaker.Generate<TestRecursiveClass>().Should().BeEquivalentTo(new TestRecursiveClass
        {
          Child1 = new TestRecursiveClass
          {
            Child1 = default(TestRecursiveClass),
            Child2 = default(TestRecursiveClass)
          },
          Child2 = new TestRecursiveClass
          {
            Child1 = default(TestRecursiveClass),
            Child2 = default(TestRecursiveClass)
          }
        });
      }
    }

    public static IEnumerable<object[]> GetTypes()
    {
      foreach (var type in AutoGeneratorFactory.Generators.Keys)
      {
        yield return new object[] { type };
      }

      yield return new object[] { typeof(string[]) };
      yield return new object[] { typeof(TestEnum) };
      yield return new object[] { typeof(IDictionary<Guid, TestStruct>) };
      yield return new object[] { typeof(IEnumerable<TestClass>) };
      yield return new object[] { typeof(int?) };
    }

    public static void AssertGenerate(Type type, MethodInfo methodInfo, IAutoFaker faker, params object[] args)
    {
      var method = methodInfo.MakeGenericMethod(type);
      var instance = method.Invoke(faker, args);

      instance.Should().BeGenerated();
    }

    public static void AssertGenerateMany(Type type, MethodInfo methodInfo, IAutoFaker faker, params object[] args)
    {
      var method = methodInfo.MakeGenericMethod(type);
      var instances = method.Invoke(faker, args) as IEnumerable;

      instances.Should().HaveCount(AutoFaker.DefaultCount);

      foreach (var instance in instances)
      {
        instance.Should().BeGenerated();
      }
    }

    public static void AssertGenerateMany(IEnumerable<Order> instances)
    {
      instances.Should().HaveCount(AutoFaker.DefaultCount);

      foreach (var instance in instances)
      {
        instance.Should().BeGeneratedWithoutMocks();
      }
    }
  }
}

