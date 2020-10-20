using AutoBogus.Util;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus.Generators
{
  internal sealed class ExpandoObjectGenerator
    : IAutoGenerator
  {
    object IAutoGenerator.Generate(AutoGenerateContext context)
    {
      var instance = context.Instance;

#if !NETSTANDARD1_3
      // Need to copy the target dictionary to avoid mutations during population
      var target = instance as IDictionary<string, object>;
      var source = new Dictionary<string, object>(target);
      var properties = source.Where(pair => pair.Value != null);

      foreach (var property in properties)
      {
        // Configure the context
        var type = property.Value.GetType();

        context.ParentType = context.GenerateType;
        context.GenerateType = type;
        context.GenerateName = property.Key;

        if (ReflectionHelper.IsExpandoObject(type))
        {
          context.Instance = property.Value;
        }
        else
        {
          context.Instance = null;
        }

        // Generate the property values
        var generator = AutoGeneratorFactory.GetGenerator(context);
        target[property.Key] = generator.Generate(context);
      }

      // Reset the instance context
      context.Instance = instance;
#endif

      return instance;
    }
  }
}

