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

    public class Overrides
      : AutoFakerFixture, IDisposable
    {
      private const string Name = "This is a string";

      private int _id;

      private sealed class OverrideFaker
        : AutoFaker<OverrideClass>
      { }

      private class TestGeneratorOverride
        : AutoGeneratorOverride
      {
        public TestGeneratorOverride(int id)
        {
          Id = id;
        }

        private int Id { get; }

        public override bool CanOverride(AutoGenerateContext context)
        {
          return context.GenerateType == typeof(OverrideClass);
        }

        public override void Generate(AutoGenerateOverrideContext context)
        {
          base.Generate(context);

          // Set an id value
          var idProperty = context.GenerateType.GetProperty("Id");
          var idInstance = idProperty.GetValue(context.Instance);
          var setValueMethod = idProperty.PropertyType.GetMethod("SetValue");

          setValueMethod.Invoke(idInstance, new object[] { Id });
        }
      }

      public Overrides()
      {
        _id = AutoFaker.Generate<int>();

        AutoFaker.SetGeneratorOverrides(
          new TestGeneratorOverride(_id),
          new AutoGeneratorTypeOverride<string>(c => Name));
      }

      public void Dispose()
      {
        AutoFaker.SetGeneratorOverrides();
      }

      [Fact]
      public void Should_Override_For_Generate()
      {
        var faker = AutoFaker.Create();
        AssertOverrides(() => faker.Generate<OverrideClass>());
      }

      [Fact]
      public void Should_Override_For_Generate_Static()
      {
        AssertOverrides(() => AutoFaker.Generate<OverrideClass>());
      }

      [Fact]
      public void Should_Override_For_Generate_Faker()
      {
        AssertOverrides(() => AutoFaker.Generate<OverrideClass, OverrideFaker>());
      }

      [Fact]
      public void Should_Override_For_AutoFaker_T()
      {
        var faker = new AutoFaker<OverrideClass>();
        AssertOverrides(() => faker.Generate());
      }

      private void AssertOverrides(Func<OverrideClass> invoker)
      {
        var instance = invoker.Invoke();

        instance.Id.Value.Should().Be(_id);
        instance.Name.Should().Be(Name);
        instance.Amounts.Should().NotBeEmpty();
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
      private Faker<Order> _faker;

      public AutoFaker_T()
      {
        _faker = new AutoFaker<Order>();
      }

      [Fact]
      public void Should_Generate_Type()
      {
        _faker.Generate().Should().BeGeneratedWithoutMocks();
      }

      [Fact]
      public void Should_Populate_Instance()
      {
        var faker = new Faker();
        var id = faker.Random.Int();
        var calculator = Substitute.For<ICalculator>();
        var order = new Order(id, calculator);

        _faker.Populate(order);

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
        var order = _faker
          .RuleFor(o => o.Code, code)
          .Generate();

        order.Should().BeGeneratedWithoutMocks();
        order.Code.Should().Be(code);
      }

      [Fact]
      public void Should_Not_Generate_If_No_Default_Rule_Set()
      {
        _faker.RuleSet("test", rules =>
        {
          // No default constructor so ensure a create action is defined
          // Make the values default so the NotBeGenerated() check passes
          rules.CustomInstantiator(f => new Order(default(int), default(ICalculator)));
        });

        _faker.Generate("test").Should().NotBeGenerated();
      }
    }

    public class Behaviors_Types
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
    }

    public class Behaviors_Recursive
      : AutoFakerFixture
    {
      private TestRecursiveClass _instance;

      public Behaviors_Recursive()
      {
        _instance = AutoFaker.Generate<TestRecursiveClass>();
      }

      [Fact]
      public void Should_Generate_Recursive_Types()
      {
        var item = new TestRecursiveClass
        {
          Child = default(TestRecursiveClass),
          Children = default(IEnumerable<TestRecursiveClass>),
          Sub = new TestRecursiveSubClass
          {
            Value = default(TestRecursiveClass)
          }
        };

        _instance.Child.Should().BeEquivalentTo(new TestRecursiveClass
        {
          Child = default(TestRecursiveClass),
          Children = new[]
          {
            item,
            item,
            item
          },
          Sub = new TestRecursiveSubClass
          {
            Value = default(TestRecursiveClass)
          }
        });
      }

      [Fact]
      public void Should_Generate_Recursive_Lists()
      {
        var item = new TestRecursiveClass
        {
          Child = new TestRecursiveClass
          {
            Child = default(TestRecursiveClass),
            Children = default(IEnumerable<TestRecursiveClass>),
            Sub = new TestRecursiveSubClass
            {
              Value = default(TestRecursiveClass)
            }
          },
          Children = default(IEnumerable<TestRecursiveClass>),
          Sub = new TestRecursiveSubClass
          {
            Value = new TestRecursiveClass
            {
              Child = default(TestRecursiveClass),
              Children = default(IEnumerable<TestRecursiveClass>),
              Sub = default(TestRecursiveSubClass)
            }
          }
        };

        _instance.Children.Should().BeEquivalentTo(new[]
        {
          item,
          item,
          item
        });
      }

      [Fact]
      public void Should_Generate_Recursive_Sub_Types()
      {
        var item = new TestRecursiveClass
        {
          Child = default(TestRecursiveClass),
          Children = default(IEnumerable<TestRecursiveClass>),
          Sub = default(TestRecursiveSubClass)
        };

        _instance.Sub.Should().BeEquivalentTo(new TestRecursiveSubClass
        {
          Value = new TestRecursiveClass
          {
            Child = default(TestRecursiveClass),
            Children = new[]
            {
              item,
              item,
              item
            },
            Sub = default(TestRecursiveSubClass)
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

