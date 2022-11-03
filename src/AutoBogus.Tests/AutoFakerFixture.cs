using AutoBogus.Tests.Models;
using AutoBogus.Tests.Models.Complex;
using AutoBogus.Tests.Models.Simple;
using Bogus;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoFakerFixture
  {
    private class TestFaker
      : AutoFaker<Order>
    { }

    private class TestBinder
      : AutoBinder
    { }

    private const string _name = "Generate";
    private static Type _type = typeof(AutoFaker);

    public class Configure
      : AutoFakerFixture
    {
      [Fact]
      public void Should_Configure_Default_Config()
      {
        AutoConfig config = null;
        AutoFaker.Configure(builder =>
        {
          var instance = builder as AutoConfigBuilder;
          config = instance.Config;
        });

        config.Should().Be(AutoFaker.DefaultConfig);
      }
    }

    public class Create
      : AutoFakerFixture
    {
      [Fact]
      public void Should_Configure_Child_Config()
      {
        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(AutoFaker.DefaultConfig);
        AutoFaker.Create(configure).Should().BeOfType<AutoFaker>();
      }
    }

    public class Generate_Instance
      : AutoFakerFixture
    {
      private static Type _interfaceType = typeof(IAutoFaker);
      private static string _methodName = $"{_interfaceType.FullName}.{_name}";
      private static MethodInfo _generate = _type.GetMethod(_methodName, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Action<IAutoGenerateConfigBuilder>) }, null);
      private static MethodInfo _generateMany = _type.GetMethod(_methodName, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(int), typeof(Action<IAutoGenerateConfigBuilder>) }, null);

      private IAutoFaker _faker;
      private AutoConfig _config;

      public Generate_Instance()
      {
        var faker = AutoFaker.Create() as AutoFaker;

        _faker = faker;
        _config = faker.Config;
      }

      [Theory]
      [MemberData(nameof(GetTypes))]
      public void Should_Generate_Type(Type type)
      {
        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(_config);
        AssertGenerate(type, _generate, _faker, configure);
      }

      [Theory]
      [MemberData(nameof(GetTypes))]
      public void Should_Generate_Many_Types(Type type)
      {
        var count = AutoConfig.DefaultRepeatCount.Invoke(null);
        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(_config);

        AssertGenerateMany(type, _generateMany, _faker, count, configure);
      }

      [Fact]
      public void Should_Generate_Complex_Type()
      {
        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(_config);
        _faker.Generate<Order>(configure).Should().BeGeneratedWithoutMocks();
      }

      [Fact]
      public void Should_Generate_Many_Complex_Types()
      {
        var count = AutoConfig.DefaultRepeatCount.Invoke(null);
        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(_config);
        var instances = _faker.Generate<Order>(count, configure);

        AssertGenerateMany(instances);
      }
    }

    public class Generate_Instance_Faker
      : AutoFakerFixture
    {
      private IAutoFaker _faker;
      private AutoConfig _config;

      public Generate_Instance_Faker()
      {
        var faker = AutoFaker.Create() as AutoFaker;

        _faker = faker;
        _config = faker.Config;
      }

      [Fact]
      public void Should_Generate_Complex_Type()
      {
        var configure = CreateConfigure<IAutoFakerConfigBuilder>(AutoFaker.DefaultConfig);
        _faker.Generate<Order, TestFaker>(configure).Should().BeGeneratedWithoutMocks();
      }

      [Fact]
      public void Should_Generate_Many_Complex_Types()
      {
        var count = AutoConfig.DefaultRepeatCount.Invoke(null);
        var configure = CreateConfigure<IAutoFakerConfigBuilder>(AutoFaker.DefaultConfig);
        var instances = _faker.Generate<Order, TestFaker>(count, configure);

        AssertGenerateMany(instances);
      }
    }

    public class Generate_Static
      : AutoFakerFixture
    {
      private static MethodInfo _generate = _type.GetMethod(_name, BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(Action<IAutoGenerateConfigBuilder>) }, null);
      private static MethodInfo _generateMany = _type.GetMethod(_name, BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(int), typeof(Action<IAutoGenerateConfigBuilder>) }, null);

      [Theory]
      [MemberData(nameof(GetTypes))]
      public void Should_Generate_Type(Type type)
      {
        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(AutoFaker.DefaultConfig);
        AssertGenerate(type, _generate, null, configure);
      }

      [Theory]
      [MemberData(nameof(GetTypes))]
      public void Should_Generate_Many_Types(Type type)
      {
        var count = AutoConfig.DefaultRepeatCount.Invoke(null);
        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(AutoFaker.DefaultConfig);

        AssertGenerateMany(type, _generateMany, null, count, configure);
      }

      [Fact]
      public void Should_Generate_Complex_Type()
      {
        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(AutoFaker.DefaultConfig);
        AutoFaker.Generate<Order>(configure).Should().BeGeneratedWithoutMocks();
      }

      [Fact]
      public void Should_Generate_Many_Complex_Types()
      {
        var count = AutoConfig.DefaultRepeatCount.Invoke(null);
        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(AutoFaker.DefaultConfig);
        var instances = AutoFaker.Generate<Order>(count, configure);

        AssertGenerateMany(instances);
      }
    }

    public class Generate_Static_Faker
      : AutoFakerFixture
    {
      [Fact]
      public void Should_Generate_Complex_Type()
      {
        var configure = CreateConfigure<IAutoFakerConfigBuilder>(AutoFaker.DefaultConfig);
        AutoFaker.Generate<Order, TestFaker>(configure).Should().BeGeneratedWithoutMocks();
      }

      [Fact]
      public void Should_Generate_Many_Complex_Types()
      {
        var count = AutoConfig.DefaultRepeatCount.Invoke(null);
        var configure = CreateConfigure<IAutoFakerConfigBuilder>(AutoFaker.DefaultConfig);
        var instances = AutoFaker.Generate<Order, TestFaker>(count, configure);

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
      public void Should_Populate_ExpandoObject()
      {
        var faker = new AutoFaker<dynamic>();

        dynamic instance = new ExpandoObject();
        dynamic child = new ExpandoObject();

        instance.Property = string.Empty;
        instance.Child = child;

        child.Property = 0;

        faker.Populate(instance);

        string property = instance.Property;
        int childProperty = instance.Child.Property;

        property.Should().NotBeEmpty();
        childProperty.Should().NotBe(0);
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
        binder.GetMembers(typeof(Order)).Returns(new Dictionary<string, MemberInfo>());

        var order = new AutoFaker<Order>(binder)
          .CustomInstantiator(faker => new Order(default, default))
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
          rules.CustomInstantiator(f => new Order(default, default));
        });

        _faker.Generate("test").Should().NotBeGenerated();
      }

      [Fact]
      public void Should_Call_FinishWith()
      {
        Order instance = null;
        var order = new AutoFaker<Order>()
          .FinishWith((f, i) => instance = i)
          .Generate();

        order.Should().BeGeneratedWithoutMocks();
        instance.Should().Be(order);
      }

      [Fact]
      public void Should_Not_Initialize_Properties_Twice()
      {
        // Arrange
        var random1 = new Randomizer(12345);
        var random2 = new Randomizer(12345);

        var faker = new Faker() { Random = random1 };

        var autoFaker = new AutoFaker<TestClassWithSingleProperty<int>>();

        autoFaker.Configure(
          builder => builder.WithFakerHub(faker));

        // Act
        var instance = autoFaker.Generate(); // Should pull one int from random1

        var expectedValue = random2.Int();

        // Assert
        instance.Value.Should().Be(expectedValue);
      }
    }

    public class AutoFaker_WithFakerHub
      : AutoFakerFixture
    {
      [Fact]
      public void Should_Use_Caller_Supplied_FakerHub()
      {
        // We infer that our FakerHub was used by reseeding it and testing that we get the same sequence both times.
        var fakerHub = new Faker();

        var configure = CreateConfigure<IAutoGenerateConfigBuilder>(
          AutoFaker.DefaultConfig,
          builder => builder.WithFakerHub(fakerHub));

        var faker = AutoFaker.Create(configure);

        fakerHub.Random = new Randomizer(1);

        var instance1 = faker.Generate<TestObject>();

        fakerHub.Random = new Randomizer(1);

        var instance2 = faker.Generate<TestObject>();

        instance1.Should().BeEquivalentTo(instance2);
      }

      class TestObject
      {
        public int IntegerValue;
        public string StringValue;
      }
    }

    public class Behaviors_Skip
      : AutoFakerFixture
    {
      [Fact]
      public void Should_Skip_Configured_Types()
      {
        var instance = AutoFaker.Generate<Order>(builder =>
        {
          builder
            .WithSkip<ICalculator>()
            .WithSkip<Guid?>();
        });

        instance.Calculator.Should().BeNull();
        instance.Code.Should().BeNull();
      }

      [Fact]
      public void Should_Skip_Configured_Members()
      {
        var instance = AutoFaker.Generate<Order>(builder =>
        {
          builder
            .WithSkip<Order>(o => o.Discounts)
            .WithSkip<OrderItem>(i => i.Discounts);
        });

        instance.Discounts.Should().BeNull();
        instance.Items.Should().OnlyContain(i => i.Discounts == null);
      }

      [Fact]
      public void Should_Skip_Configured_Members_Of_Interface()
      {
        var instance = AutoFaker.Generate<Order>(builder =>
        {
          builder
            .WithSkip<IWithCode>(i => i.Code);
        });

        instance.Code.Should().BeNull();
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
        _instance = AutoFaker.Generate<TestRecursiveClass>(builder =>
        {
          builder.WithRecursiveDepth(3);
        });
      }

      [Fact]
      public void Should_Generate_Recursive_Types()
      {
        _instance.Child.Should().NotBeNull();
        _instance.Child.Child.Should().NotBeNull();
        _instance.Child.Child.Child.Should().NotBeNull();
        _instance.Child.Child.Child.Child.Should().BeNull();
      }

      [Fact]
      public void Should_Generate_Recursive_Lists()
      {
        var children = _instance.Children;
        var children1 = children.SelectMany(c => c.Children).ToList();
        var children2 = children1.SelectMany(c => c.Children).ToList();
        var children3 = children2.Where(c => c.Children != null).ToList();

        children.Should().HaveCount(3);
        children1.Should().HaveCount(9);
        children2.Should().HaveCount(27);
        children3.Should().HaveCount(0);
      }

      [Fact]
      public void Should_Generate_Recursive_Sub_Types()
      {
        _instance.Sub.Should().NotBeNull();
        _instance.Sub.Value.Sub.Should().NotBeNull();
        _instance.Sub.Value.Sub.Value.Sub.Should().NotBeNull();
        _instance.Sub.Value.Sub.Value.Sub.Value.Sub.Should().BeNull();
      }
    }

    public class Obsolete
    {
      #region Obsolete Instance

      public class Generate_Instance_Faker
        : AutoFakerFixture
      {
        private IAutoFaker _faker;

        public Generate_Instance_Faker()
        {
          _faker = AutoFaker.Create();
        }

        [Fact]
        public void Should_Generate_Complex_Type()
        {
          _faker.Generate<Order, TestFaker>(new object[0]).Should().BeGeneratedWithoutMocks();
        }

        [Fact]
        public void Should_Generate_Many_Complex_Types()
        {
          var count = AutoConfig.DefaultRepeatCount.Invoke(null);
          var instances = _faker.Generate<Order, TestFaker>(count, new object[0]);

          AssertGenerateMany(instances);
        }
      }

      #endregion

      #region Obsolete Static

      public class Create
        : AutoFakerFixture
      {
        [Fact]
        public void Should_Configure_Locale()
        {
          AutoFaker.Create(AutoConfig.DefaultLocale).Should().BeOfType<AutoFaker>();
        }

        [Fact]
        public void Should_Configure_Binder_With_Instance()
        {
          AutoFaker.Create(new TestBinder()).Should().BeOfType<AutoFaker>();
        }

        [Fact]
        public void Should_Configure_Locale_And_Binder()
        {
          AutoFaker.Create<TestBinder>(AutoConfig.DefaultLocale).Should().BeOfType<AutoFaker>();
        }

        [Fact]
        public void Should_Configure_Locale_And_Binder_With_Instance()
        {
          AutoFaker.Create(AutoConfig.DefaultLocale, new TestBinder()).Should().BeOfType<AutoFaker>();
        }
      }

      public class SetBinder
        : AutoFakerFixture, IDisposable
      {
        [Fact]
        public void Should_Configure_Binder()
        {
          AutoFaker.SetBinder<TestBinder>();

          AutoFaker.DefaultConfig.Binder.Should().BeOfType<TestBinder>();
        }

        [Fact]
        public void Should_Configure_Binder_With_Instance()
        {
          var binder = new TestBinder();

          AutoFaker.SetBinder(binder);

          AutoFaker.DefaultConfig.Binder.Should().Be(binder);
        }

        public void Dispose()
        {
          // Clear the binder to ensure other tests are not affected - its static
          AutoFaker.SetBinder(null);
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
          AssertGenerate(type, _generate, null, AutoConfig.DefaultLocale);
        }

        [Theory]
        [MemberData(nameof(GetTypes))]
        public void Should_Generate_Many_Types(Type type)
        {
          var count = AutoConfig.DefaultRepeatCount.Invoke(null);
          AssertGenerateMany(type, _generateMany, null, count, AutoConfig.DefaultLocale);
        }

        [Fact]
        public void Should_Generate_Complex_Type()
        {
          AutoFaker.Generate<Order>(AutoConfig.DefaultLocale).Should().BeGeneratedWithoutMocks();
        }

        [Fact]
        public void Should_Generate_Many_Complex_Types()
        {
          var count = AutoConfig.DefaultRepeatCount.Invoke(null);
          var instances = AutoFaker.Generate<Order>(count, AutoConfig.DefaultLocale);

          AssertGenerateMany(instances);
        }
      }

      public class Generate_Static_Faker
        : AutoFakerFixture
      {
        [Fact]
        public void Should_Generate_Complex_Type()
        {
          AutoFaker.Generate<Order, TestFaker>(new object[0]).Should().BeGeneratedWithoutMocks();
        }

        [Fact]
        public void Should_Generate_Many_Complex_Types()
        {
          var count = AutoConfig.DefaultRepeatCount.Invoke(null);
          var instances = AutoFaker.Generate<Order, TestFaker>(count, new object[0]);

          AssertGenerateMany(instances);
        }
      }

      #endregion
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

    private Action<TBuilder> CreateConfigure<TBuilder>(AutoConfig assertConfig, Action<TBuilder> configure = null)
    {
      return builder =>
      {
        if (configure != null)
        {
          configure.Invoke(builder);
        }

        var instance = builder as AutoConfigBuilder;
        instance.Config.Should().NotBe(assertConfig);
      };
    }

    public static void AssertGenerate(Type type, MethodInfo methodInfo, IAutoFaker faker, params object[] args)
    {
      var method = methodInfo.MakeGenericMethod(type);
      var instance = method.Invoke(faker, args);

      instance.Should().BeGenerated();
    }

    public static void AssertGenerateMany(Type type, MethodInfo methodInfo, IAutoFaker faker, params object[] args)
    {
      var count = AutoConfig.DefaultRepeatCount.Invoke(null);
      var method = methodInfo.MakeGenericMethod(type);
      var instances = method.Invoke(faker, args) as IEnumerable;

      instances.Should().HaveCount(count);

      foreach (var instance in instances)
      {
        instance.Should().BeGenerated();
      }
    }

    public static void AssertGenerateMany(IEnumerable<Order> instances)
    {
      var count = AutoConfig.DefaultRepeatCount.Invoke(null);

      instances.Should().HaveCount(count);

      foreach (var instance in instances)
      {
        instance.Should().BeGeneratedWithoutMocks();
      }
    }
  }
}

