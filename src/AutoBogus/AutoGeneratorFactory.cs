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
      {typeof(Uri), new UriGenerator()},
      {typeof(ushort), new UShortGenerator()}
    };

    internal static IAutoGenerator GetGenerator(AutoGenerateContext context)
    {
      var generator = ResolveGenerator(context);

      // Check if any overrides are available for this generate request
      var overrides = context.Overrides.Where(o => o.CanOverride(context)).ToList();

      if (overrides.Any())
      {
        return new AutoGeneratorOverrideInvoker(generator, overrides);
      }

      return generator;
    }

    private static IAutoGenerator ResolveGenerator(AutoGenerateContext context)
    {
      var type = context.GenerateType;

      // Need check if the type is an in/out parameter and adjusted accordingly
      if (type.IsByRef)
      {
        type = type.GetElementType();
      }

      // Check if an expando object needs to generator
      // This actually means an existing dictionary needs to be populated
      if (ReflectionHelper.IsExpandoObject(type))
      {
        return new ExpandoObjectGenerator();
      }

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
        var generics = ReflectionHelper.GetGenericArguments(type);

        if (ReflectionHelper.IsReadOnlyDictionary(type))
        {
          var keyType = generics.ElementAt(0);
          var valueType = generics.ElementAt(1);

          return CreateGenericGenerator(typeof(ReadOnlyDictionaryGenerator<,>), keyType, valueType);
        }

        if (ReflectionHelper.IsDictionary(type))
        {
          return CreateDicitonaryGenerator(generics);
        }

        if (ReflectionHelper.IsSet(type))
        {
          type = generics.Single();
          return CreateGenericGenerator(typeof(SetGenerator<>), type);
        }

        if (ReflectionHelper.IsEnumerable(type))
        {
          // If the type has more than one generic use a dictionary (hasn't been resolved by dictionary check above)
          // Example is a Dictionary<T, U>.KeyCollection
          if (generics.Count() == 2)
          {
            return CreateDicitonaryGenerator(generics);
          }

          // Otherwise it is a list type
          type = generics.Single();
          return CreateGenericGenerator(typeof(EnumerableGenerator<>), type);
        }

        if (ReflectionHelper.IsNullable(type))
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

    private static IAutoGenerator CreateDicitonaryGenerator(IEnumerable<Type> generics)
    {
      var keyType = generics.ElementAt(0);
      var valueType = generics.ElementAt(1);

      return CreateGenericGenerator(typeof(DictionaryGenerator<,>), keyType, valueType);
    }

    private static IAutoGenerator CreateGenericGenerator(Type generatorType, params Type[] genericTypes)
    {
      var type = generatorType.MakeGenericType(genericTypes);
      return (IAutoGenerator)Activator.CreateInstance(type);
    }
  }
}
