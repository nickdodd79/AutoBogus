using AutoBogus.Generators;
using AutoBogus.Tests.Models.Simple;
using AutoBogus.Util;
using FluentAssertions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace AutoBogus.Tests
{
  public partial class AutoGeneratorsFixture
  {    
    public class ReadOnlyDictionaryGenerator
      : AutoGeneratorsFixture
    {
      [Theory]
      [InlineData(typeof(IReadOnlyDictionary<int, string>))]
      [InlineData(typeof(ReadOnlyDictionary<int, string>))]
      public void Generate_Should_Return_Dictionary(Type type)
      {
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var keyType = genericTypes.ElementAt(0);
        var valueType = genericTypes.ElementAt(1);
        var generator = CreateGenerator(typeof(ReadOnlyDictionaryGenerator<,>), keyType, valueType);
        var dictionary = InvokeGenerator(type, generator) as IReadOnlyDictionary<int, string>;

        dictionary.Should().NotBeNull().And.NotContainNulls();

        foreach (var key in dictionary.Keys)
        {
          var value = dictionary[key];

          key.Should().BeOfType(keyType);
          value.Should().BeOfType(valueType);
        }
      }

      [Theory]
      [InlineData(typeof(IReadOnlyDictionary<int, TestEnum>))]
      [InlineData(typeof(IReadOnlyDictionary<int, TestStruct>))]
      [InlineData(typeof(IReadOnlyDictionary<int, TestClass>))]
      [InlineData(typeof(IReadOnlyDictionary<int, ITestInterface>))]
      [InlineData(typeof(IReadOnlyDictionary<int, TestAbstractClass>))]
      [InlineData(typeof(ReadOnlyDictionary<int, TestClass>))]
      public void GetGenerator_Should_Return_ReadOnlyDictionaryGenerator(Type type)
      {
        var context = CreateContext(type);
        var genericTypes = ReflectionHelper.GetGenericArguments(type);
        var keyType = genericTypes.ElementAt(0);
        var valueType = genericTypes.ElementAt(1);
        var generatorType = GetGeneratorType(typeof(ReadOnlyDictionaryGenerator<,>), keyType, valueType);

        AutoGeneratorFactory.GetGenerator(context).Should().BeOfType(generatorType);
      }
    }
  }
}
