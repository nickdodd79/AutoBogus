using AutoBogus.Generators;
using AutoBogus.Tests.Models.Simple;
using AutoBogus.Util;
using Bogus;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Xunit;

namespace AutoBogus.Tests
{
  public partial class AutoGeneratorsFixture
  {
    public class Factory
    {
      public class ReadOnlyDictionary
      {
        public class ReadOnlyDictionaryBase<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
        {
          public ReadOnlyDictionaryBase(IEnumerable<KeyValuePair<TKey, TValue>> items)
          {
            foreach (var item in items)
              _store[item.Key] = item.Value;
          }

          Dictionary<TKey, TValue> _store = new Dictionary<TKey, TValue>();

          public TValue this[TKey key] => _store[key];
          public IEnumerable<TKey> Keys => _store.Keys;
          public IEnumerable<TValue> Values => _store.Values;
          public int Count => _store.Count;

          public bool ContainsKey(TKey key) => _store.ContainsKey(key);
          public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _store.GetEnumerator();
          public bool TryGetValue(TKey key, out TValue value) => _store.TryGetValue(key, out value);
          IEnumerator IEnumerable.GetEnumerator() => _store.GetEnumerator();
        }

        public class NonGeneric : ReadOnlyDictionaryBase<int, string>
        {
          public NonGeneric(IEnumerable<KeyValuePair<int, string>> items) : base(items)
          {
          }
        }

        public class OneArgument<T> : ReadOnlyDictionaryBase<T, string>
        {
          public OneArgument(IEnumerable<KeyValuePair<T, string>> items) : base(items)
          {
          }
        }

        public class TwoArgumentsThatAreDifferentFromBaseReadOnlyDictionaryClass<TValue, TKey> : ReadOnlyDictionaryBase<TKey, TValue>
        {
          public TwoArgumentsThatAreDifferentFromBaseReadOnlyDictionaryClass(IEnumerable<KeyValuePair<TKey, TValue>> items) : base(items)
          {
          }
        }

        public static IEnumerable<object[]> ListOfReadOnlyDictionaryTypes
        {
          get
          {
            yield return new[] { typeof(NonGeneric) };
            yield return new[] { typeof(OneArgument<int>) };
            yield return new[] { typeof(TwoArgumentsThatAreDifferentFromBaseReadOnlyDictionaryClass<string, int>) };
          }
        }

        [Theory]
        [MemberData(nameof(ListOfReadOnlyDictionaryTypes))]
        public void Should_Handle_Subclasses(Type readOnlyDictionaryType)
        {
          // Arrange
          var config = new AutoConfig();

          var context = new AutoGenerateContext(config);

          context.GenerateType = readOnlyDictionaryType;

          // Act
          var generator = AutoGeneratorFactory.ResolveGenerator(context);

          var instance = generator.Generate(context);

          // Arrange
          generator.Should().BeOfType<ReadOnlyDictionaryGenerator<int, string>>();

          instance.Should().BeOfType(readOnlyDictionaryType);
        }
      }

      public class Dictionary
      {
        public class NonGeneric : Dictionary<int, string>
        {
        }

        public class OneArgument<T> : Dictionary<T, string>
        {
        }

        public class TwoArgumentsThatAreDifferentFromBaseDictionaryClass<TValue, TKey> : Dictionary<TKey, TValue>
        {
        }

        public static IEnumerable<object[]> ListOfDictionaryTypes
        {
          get
          {
            yield return new[] { typeof(NonGeneric) };
            yield return new[] { typeof(OneArgument<int>) };
            yield return new[] { typeof(TwoArgumentsThatAreDifferentFromBaseDictionaryClass<string, int>) };
          }
        }

        [Theory]
        [MemberData(nameof(ListOfDictionaryTypes))]
        public void Should_Handle_Subclasses(Type dictionaryType)
        {
          // Arrange
          var config = new AutoConfig();

          var context = new AutoGenerateContext(config);

          context.GenerateType = dictionaryType;

          // Act
          var generator = AutoGeneratorFactory.ResolveGenerator(context);

          var instance = generator.Generate(context);

          // Arrange
          generator.Should().BeOfType<DictionaryGenerator<int, string>>();

          instance.Should().BeOfType(dictionaryType);
        }
      }

      public class Set
      {
        public class NonGeneric : HashSet<int>
        {
        }

        public class GenericWithDifferentType<TType> : HashSet<int>
        {
          public TType Property { get; set; }
        }

        public static IEnumerable<object[]> ListOfSetTypes
        {
          get
          {
            yield return new[] { typeof(NonGeneric) };
            yield return new[] { typeof(GenericWithDifferentType<string>) };
          }
        }

        [Theory]
        [MemberData(nameof(ListOfSetTypes))]
        public void Should_Handle_Subclasses(Type setType)
        {
          // Arrange
          var config = new AutoConfig();

          var context = new AutoGenerateContext(config);

          context.GenerateType = setType;

          // Act
          var generator = AutoGeneratorFactory.ResolveGenerator(context);

          var instance = generator.Generate(context);

          // Arrange
          generator.Should().BeOfType<SetGenerator<int>>();

          instance.Should().BeOfType(setType);
        }
      }

      public class List
      {
        public class NonGeneric : List<int>
        {
        }

        public class GenericWithDifferentType<TType> : List<int>
        {
          public TType Property { get; set; }
        }

        public static IEnumerable<object[]> ListOfListTypes
        {
          get
          {
            yield return new[] { typeof(NonGeneric) };
            yield return new[] { typeof(GenericWithDifferentType<string>) };
          }
        }

        [Theory]
        [MemberData(nameof(ListOfListTypes))]
        public void Should_Handle_Subclasses(Type listType)
        {
          // Arrange
          var config = new AutoConfig();

          var context = new AutoGenerateContext(config);

          context.GenerateType = listType;

          // Act
          var generator = AutoGeneratorFactory.ResolveGenerator(context);

          var instance = generator.Generate(context);

          // Arrange
          generator.Should().BeOfType<ListGenerator<int>>();

          instance.Should().BeOfType(listType);
        }
      }
    }

    public class ReferenceTypes
      : AutoGeneratorsFixture
    {
      private sealed class TestClass
      {
        public TestClass(in int value)
        { }
      }

      [Fact]
      public void Should_Not_Throw_For_Reference_Types()
      {
        var type = typeof(TestClass);
        var constructor = type.GetConstructors().Single();
        var parameter = constructor.GetParameters().Single();
        var context = CreateContext(parameter.ParameterType);

        Action action = () => AutoGeneratorFactory.GetGenerator(context);
        action.Should().NotThrow();
      }
    }

    public class RegisteredGenerator
      : AutoGeneratorsFixture
    {
      [Theory]
      [MemberData(nameof(GetRegisteredTypes))]
      public void Generate_Should_Return_Value(Type type)
      {
        var generator = AutoGeneratorFactory.Generators[type];

        InvokeGenerator(type, generator).Should().BeOfType(type);
      }

      [Theory]
      [MemberData(nameof(GetRegisteredTypes))]
      public void GetGenerator_Should_Return_Generator(Type type)
      {
        var context = CreateContext(type);
        var generator = AutoGeneratorFactory.Generators[type];

        AutoGeneratorFactory.GetGenerator(context).Should().Be(generator);
      }

      public static IEnumerable<object[]> GetRegisteredTypes()
      {
        return AutoGeneratorFactory.Generators.Select(g => new object[]
        {
          g.Key
        });
      }

      [Theory]
      [MemberData(nameof(GetDataSetAndDataTableTypes))]
      public void GetGenerator_Should_Return_Generator_For_DataSets_And_DataTables(Type dataType, Type generatorType)
      {
        // Arrange
        var context = CreateContext(dataType);

        // Act
        var generator = AutoGeneratorFactory.GetGenerator(context);

        // Assert
        generator.Should().BeAssignableTo(generatorType);
      }

      public static IEnumerable<object[]> GetDataSetAndDataTableTypes()
      {
        yield return new object[] { typeof(System.Data.DataSet), typeof(DataSetGenerator) };
        yield return new object[] { typeof(DataSetGeneratorFacet.TypedDataSet), typeof(DataSetGenerator) };
        yield return new object[] { typeof(System.Data.DataTable), typeof(DataTableGenerator) };
        yield return new object[] { typeof(DataTableGeneratorFacet.TypedDataTable1), typeof(DataTableGenerator) };
        yield return new object[] { typeof(DataTableGeneratorFacet.TypedDataTable2), typeof(DataTableGenerator) };
      }
    }

    public class ExpandoObjectGenerator
      : AutoGeneratorsFixture
    {
      [Fact]
      public void Generate_Should_Return_Value()
      {
        var type = typeof(ExpandoObject);
        var generator = new Generators.ExpandoObjectGenerator();

        dynamic instance = new ExpandoObject();
        dynamic child = new ExpandoObject();

        instance.Property = string.Empty;
        instance.Child = child;

        child.Property = 0;

        InvokeGenerator(type, generator, instance);

        string property = instance.Property;
        int childProperty = instance.Child.Property;

        property.Should().NotBeEmpty();
        childProperty.Should().NotBe(0);
      }

      [Fact]
      public void GetGenerator_Should_Return_NullableGenerator()
      {
        var type = typeof(ExpandoObject);
        var context = CreateContext(type);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType<Generators.ExpandoObjectGenerator>();
      }
    }

    public class ArrayGenerator
      : AutoGeneratorsFixture
    {
      [Theory]
      [InlineData(typeof(TestEnum[]))]
      [InlineData(typeof(TestStruct[]))]
      [InlineData(typeof(TestClass[]))]
      [InlineData(typeof(ITestInterface[]))]
      [InlineData(typeof(TestAbstractClass[]))]
      public void Generate_Should_Return_Array(Type type)
      {
        var itemType = type.GetElementType();
        var generator = CreateGenerator(typeof(ArrayGenerator<>), itemType);
        var array = InvokeGenerator(type, generator) as Array;

        array.Should().NotBeNull().And.NotContainNulls();
      }

      [Theory]
      [InlineData(typeof(TestEnum[]))]
      [InlineData(typeof(TestStruct[]))]
      [InlineData(typeof(TestClass[]))]
      [InlineData(typeof(ITestInterface[]))]
      [InlineData(typeof(TestAbstractClass[]))]
      public void GetGenerator_Should_Return_ArrayGenerator(Type type)
      {
        var context = CreateContext(type);
        var itemType = type.GetElementType();
        var generatorType = GetGeneratorType(typeof(ArrayGenerator<>), itemType);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType(generatorType);
      }
    }

    public class EnumGenerator
      : AutoGeneratorsFixture
    {
      [Fact]
      public void Generate_Should_Return_Enum()
      {
        var type = typeof(TestEnum);
        var generator = new EnumGenerator<TestEnum>();

        InvokeGenerator(type, generator).Should().BeOfType<TestEnum>();
      }

      [Fact]
      public void GetGenerator_Should_Return_EnumGenerator()
      {
        var type = typeof(TestEnum);
        var context = CreateContext(type);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType<EnumGenerator<TestEnum>>();
      }
    }

    public class DictionaryGenerator
      : AutoGeneratorsFixture
    {
      [Theory]
      [InlineData(typeof(IDictionary<int, TestEnum>))]
      [InlineData(typeof(IDictionary<int, TestStruct>))]
      [InlineData(typeof(IDictionary<int, TestClass>))]
      [InlineData(typeof(IDictionary<int, ITestInterface>))]
      [InlineData(typeof(IDictionary<int, TestAbstractClass>))]
      [InlineData(typeof(Dictionary<int, TestClass>))]
      [InlineData(typeof(SortedList<int, TestClass>))]
      public void Generate_Should_Return_Dictionary(Type type)
      {
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var keyType = genericTypes.ElementAt(0);
        var valueType = genericTypes.ElementAt(1);
        var generator = CreateGenerator(typeof(DictionaryGenerator<,>), keyType, valueType);
        var dictionary = InvokeGenerator(type, generator) as IDictionary;

        dictionary.Should().NotBeNull().And.NotContainNulls();

        foreach (var key in dictionary.Keys)
        {
          var value = dictionary[key];

          key.Should().BeOfType(keyType);
          value.Should().BeOfType(valueType);
        }
      }

      [Theory]
      [InlineData(typeof(IDictionary<int, TestEnum>))]
      [InlineData(typeof(IDictionary<int, TestStruct>))]
      [InlineData(typeof(IDictionary<int, TestClass>))]
      [InlineData(typeof(IDictionary<int, ITestInterface>))]
      [InlineData(typeof(IDictionary<int, TestAbstractClass>))]
      [InlineData(typeof(Dictionary<int, TestClass>))]
      [InlineData(typeof(SortedList<int, TestClass>))]
      public void GetGenerator_Should_Return_DictionaryGenerator(Type type)
      {
        var context = CreateContext(type);
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var keyType = genericTypes.ElementAt(0);
        var valueType = genericTypes.ElementAt(1);
        var generatorType = GetGeneratorType(typeof(DictionaryGenerator<,>), keyType, valueType);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType(generatorType);
      }
    }

    public class ListGenerator
      : AutoGeneratorsFixture
    {
      [Theory]
      [InlineData(typeof(IList<TestEnum>))]
      [InlineData(typeof(IList<TestStruct>))]
      [InlineData(typeof(IList<TestClass>))]
      [InlineData(typeof(IList<ITestInterface>))]
      [InlineData(typeof(IList<TestAbstractClass>))]
      [InlineData(typeof(ICollection<TestEnum>))]
      [InlineData(typeof(ICollection<TestStruct>))]
      [InlineData(typeof(ICollection<TestClass>))]
      [InlineData(typeof(ICollection<ITestInterface>))]
      [InlineData(typeof(ICollection<TestAbstractClass>))]
      [InlineData(typeof(List<TestClass>))]
      public void Generate_Should_Return_List(Type type)
      {
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var itemType = genericTypes.ElementAt(0);
        var generator = CreateGenerator(typeof(ListGenerator<>), itemType);
        var list = InvokeGenerator(type, generator) as IEnumerable;

        list.Should().NotBeNull().And.NotContainNulls();
      }

      [Theory]
      [InlineData(typeof(IList<TestEnum>))]
      [InlineData(typeof(IList<TestStruct>))]
      [InlineData(typeof(IList<TestClass>))]
      [InlineData(typeof(IList<ITestInterface>))]
      [InlineData(typeof(IList<TestAbstractClass>))]
      [InlineData(typeof(ICollection<TestEnum>))]
      [InlineData(typeof(ICollection<TestStruct>))]
      [InlineData(typeof(ICollection<TestClass>))]
      [InlineData(typeof(ICollection<ITestInterface>))]
      [InlineData(typeof(ICollection<TestAbstractClass>))]
      [InlineData(typeof(List<TestClass>))]
      public void GetGenerator_Should_Return_ListGenerator(Type type)
      {
        var context = CreateContext(type);
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var itemType = genericTypes.ElementAt(0);
        var generatorType = GetGeneratorType(typeof(ListGenerator<>), itemType);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType(generatorType);
      }
    }

    public class SetGenerator
      : AutoGeneratorsFixture
    {
      [Theory]
      [InlineData(typeof(ISet<TestEnum>))]
      [InlineData(typeof(ISet<TestStruct>))]
      [InlineData(typeof(ISet<TestClass>))]
      [InlineData(typeof(ISet<ITestInterface>))]
      [InlineData(typeof(ISet<TestAbstractClass>))]
      [InlineData(typeof(HashSet<TestClass>))]
      public void Generate_Should_Return_Set(Type type)
      {
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var itemType = genericTypes.ElementAt(0);
        var generator = CreateGenerator(typeof(SetGenerator<>), itemType);
        var set = InvokeGenerator(type, generator) as IEnumerable;

        set.Should().NotBeNull().And.NotContainNulls();
      }

      [Theory]
      [InlineData(typeof(ISet<TestEnum>))]
      [InlineData(typeof(ISet<TestStruct>))]
      [InlineData(typeof(ISet<TestClass>))]
      [InlineData(typeof(ISet<ITestInterface>))]
      [InlineData(typeof(ISet<TestAbstractClass>))]
      [InlineData(typeof(HashSet<TestClass>))]
      public void GetGenerator_Should_Return_SetGenerator(Type type)
      {
        var context = CreateContext(type);
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var itemType = genericTypes.ElementAt(0);
        var generatorType = GetGeneratorType(typeof(SetGenerator<>), itemType);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType(generatorType);
      }
    }

    public class EnumerableGenerator
      : AutoGeneratorsFixture
    {
      [Theory]
      [InlineData(typeof(IEnumerable<TestEnum>))]
      [InlineData(typeof(IEnumerable<TestStruct>))]
      [InlineData(typeof(IEnumerable<TestClass>))]
      [InlineData(typeof(IEnumerable<ITestInterface>))]
      [InlineData(typeof(IEnumerable<TestAbstractClass>))]
      public void Generate_Should_Return_Enumerable(Type type)
      {
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var itemType = genericTypes.ElementAt(0);
        var generator = CreateGenerator(typeof(EnumerableGenerator<>), itemType);
        var enumerable = InvokeGenerator(type, generator) as IEnumerable;

        enumerable.Should().NotBeNull().And.NotContainNulls();
      }

      [Theory]
      [InlineData(typeof(IEnumerable<TestEnum>))]
      [InlineData(typeof(IEnumerable<TestStruct>))]
      [InlineData(typeof(IEnumerable<TestClass>))]
      [InlineData(typeof(IEnumerable<ITestInterface>))]
      [InlineData(typeof(IEnumerable<TestAbstractClass>))]
      public void GetGenerator_Should_Return_EnumerableGenerator(Type type)
      {
        var context = CreateContext(type);
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var itemType = genericTypes.ElementAt(0);
        var generatorType = GetGeneratorType(typeof(EnumerableGenerator<>), itemType);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType(generatorType);
      }
    }

    public class NullableGenerator
      : AutoGeneratorsFixture
    {
      [Fact]
      public void Generate_Should_Return_Value()
      {
        var type = typeof(TestEnum?);
        var generator = new NullableGenerator<TestEnum>();

        InvokeGenerator(type, generator).Should().BeOfType<TestEnum>();
      }

      [Fact]
      public void GetGenerator_Should_Return_NullableGenerator()
      {
        var type = typeof(TestEnum?);
        var context = CreateContext(type);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType<NullableGenerator<TestEnum>>();
      }
    }

    public class TypeGenerator
      : AutoGeneratorsFixture
    {
      [Theory]
      [InlineData(typeof(TestStruct))]
      [InlineData(typeof(TestClass))]
      [InlineData(typeof(ITestInterface))]
      [InlineData(typeof(TestAbstractClass))]
      public void Generate_Should_Return_Value(Type type)
      {
        var generator = CreateGenerator(typeof(TypeGenerator<>), type);

        if (ReflectionHelper.IsInterface(type) || ReflectionHelper.IsAbstract(type))
        {
          InvokeGenerator(type, generator).Should().BeNull();
        }
        else
        {
          InvokeGenerator(type, generator).Should().BeAssignableTo(type);
        }
      }

      [Theory]
      [InlineData(typeof(TestStruct))]
      [InlineData(typeof(TestClass))]
      [InlineData(typeof(ITestInterface))]
      [InlineData(typeof(TestAbstractClass))]
      public void GetGenerator_Should_Return_TypeGenerator(Type type)
      {
        var context = CreateContext(type);
        var generatorType = GetGeneratorType(typeof(TypeGenerator<>), type);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType(generatorType);
      }
    }

    public class GeneratorOverrides
      : AutoGeneratorsFixture
    {
      private AutoGeneratorOverride _generatorOverride;
      private IList<AutoGeneratorOverride> _overrides;

      private class TestGeneratorOverride
        : AutoGeneratorOverride
      {
        public TestGeneratorOverride(bool shouldOverride = false)
        {
          ShouldOverride = shouldOverride;
        }

        public bool ShouldOverride { get; }

        public override bool CanOverride(AutoGenerateContext context)
        {
          return ShouldOverride;
        }

        public override void Generate(AutoGenerateOverrideContext context)
        { }
      }

      public GeneratorOverrides()
      {
        _generatorOverride = new TestGeneratorOverride(true);
        _overrides = new List<AutoGeneratorOverride>
        {
          new TestGeneratorOverride(),
          _generatorOverride,
          new TestGeneratorOverride()
        };
      }

      [Fact]
      public void Should_Return_All_Matching_Overrides()
      {
        var generatorOverride = new TestGeneratorOverride(true);

        _overrides.Insert(1, generatorOverride);

        var context = CreateContext(typeof(string), _overrides);
        var invoker = AutoGeneratorFactory.GetGenerator(context) as AutoGeneratorOverrideInvoker;

        invoker.Overrides.Should().BeEquivalentTo(new[] { generatorOverride, _generatorOverride });
      }

      [Fact]
      public void Should_Return_Generator_If_No_Matching_Override()
      {
        _overrides = new List<AutoGeneratorOverride>
        {
          new TestGeneratorOverride()
        };

        var context = CreateContext(typeof(int), _overrides);
        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType<IntGenerator>();
      }

      [Fact]
      public void Should_Invoke_Generator()
      {
        var context = CreateContext(typeof(string), _overrides);
        var generatorOverride = AutoGeneratorFactory.GetGenerator(context);

        generatorOverride.Generate(context).Should().BeOfType<string>().And.Should().NotBeNull();
      }
    }

    private object InvokeGenerator(Type type, IAutoGenerator generator, object instance = null)
    {
      var context = CreateContext(type);
      context.Instance = instance;

      return generator.Generate(context);
    }

    private static Type GetGeneratorType(Type type, params Type[] types)
    {
      return type.MakeGenericType(types);
    }

    private static IAutoGenerator CreateGenerator(Type type, params Type[] types)
    {
      type = GetGeneratorType(type, types);
      return (IAutoGenerator)Activator.CreateInstance(type);
    }

    private AutoGenerateContext CreateContext(Type type, IList<AutoGeneratorOverride> generatorOverrides = null)
    {
      var faker = new Faker();
      var config = new AutoConfig();

      if (generatorOverrides != null)
      {
        config.Overrides = generatorOverrides;
      }

      return new AutoGenerateContext(faker, config)
      {
        GenerateType = type
      };
    }
  }
}
