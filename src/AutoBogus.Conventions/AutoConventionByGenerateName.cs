using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus.Conventions
{
  internal abstract class AutoConventionByGenerateName<TType>
    : IAutoConventionGenerator
  {
    protected abstract IEnumerable<string> GenerateNames { get; }

    protected abstract object Generate(AutoConventionContext context);

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(TType) &&
             GenerateNames.Any(n => n.Equals(context.GenerateName, StringComparison.OrdinalIgnoreCase));
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return Generate(context);
    }

    protected object GenerateUsing(AutoConventionContext context, Func<object> generator)
    {
      if (context.Instance == null || context.Config.AlwaysGenerate)
      {
        return generator.Invoke();
      }

      return context.Instance;
    }
  }
}
