using AutoBogus.Generators;
using AutoBogus.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus
{
  internal static class AutoGeneratorFactory
  {
    internal static IDictionary<Type, IAutoGenerator> Generators = new Dictionary<Type, IAutoGenerator>
    {
      {typeof(bool), new BoolGenerator()},
      {typeof(byte), new ByteGenerator()},
      {typeof(char), new CharGenerator()},
      {typeof(DateTime), new DateTimeGenerator()},
      {typeof(DateTimeOffset), new DateTimeOffsetGenerator()},
      {typeof(decimal), new DecimalGenerator()},
      {typeof(double), new DoubleGenerator()},
      {typeof(float), new FloatGenerator()},
      {typeof(Guid), new GuidGenerator()},
      {typeof(int), new IntGenerator()},
      {typeof(long), new LongGenerator()},
      {typeof(sbyte), new SByteGenerator()},
      {typeof(short), new ShortGenerator()},
      {typeof(string), new StringGenerator()},
      {typeof(uint), new UIntGenerator()},
      {typeof(ulong), new ULongGenerator()},
      {typeof(ushort), new UShortGenerator()}
    };

    internal static IAutoGenerator GetGenerator<TType>(AutoGenerateContext context)
    {
      var type = typeof(TType);
      return GetGenerator(type, context);
    }

    internal static IAutoGenerator GetGenerator(Type type, AutoGenerateContext context)
    {
      // Do some type -> generator mapping
      if (type.IsArray)
      {
        type = type.GetElementType();
        return CreateGenericGenerator(typeof(ArrayGenerator<>), type);
      }

      if (ReflectionHelper.IsEnum(type))
      {
        return CreateGenericGenerator(typeof(EnumGenerator<>), type);
      }

      if (ReflectionHelper.IsGenericType(type))
      {
        // For generic types we need to interrogate the inner types
        var definition = type.GetGenericTypeDefinition();
        var generics = ReflectionHelper.GetGenericArguments(type);

        if (definition == typeof(IDictionary<,>))
        {
          var keyType = generics.ElementAt(0);
          var valueType = generics.ElementAt(1);

          return CreateGenericGenerator(typeof(DictionaryGenerator<,>), keyType, valueType);
        }

        if (definition == typeof(IEnumerable<>))
        {
          type = generics.Single();
          return CreateGenericGenerator(typeof(EnumerableGenerator<>), type);
        }

        if (definition == typeof(Nullable<>))
        {
          type = generics.Single();
          return CreateGenericGenerator(typeof(NullableGenerator<>), type);
        }
      }

      // Resolve the generator from the type
      if (Generators.ContainsKey(type))
      {
        return Generators[type];
      }

      return CreateGenericGenerator(typeof(TypeGenerator<>), type);
    }

    private static IAutoGenerator CreateGenericGenerator(Type generatorType, params Type[] genericTypes)
    {
      var type = generatorType.MakeGenericType(genericTypes);
      return (IAutoGenerator)Activator.CreateInstance(type);
    }
  }
}
