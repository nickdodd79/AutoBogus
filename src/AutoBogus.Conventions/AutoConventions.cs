using System;
using System.Collections.Generic;

namespace AutoBogus.Conventions
{
  public static class AutoConventions
  {
    private static IList<IAutoConvention> Conventions = new List<IAutoConvention>
    {
      new FirstNameConvention()
    };

    public static void Build(Action<AutoConventionsContext> builder = null)
    {
      // Build the conventions context
      var context = new AutoConventionsContext();

      if (builder != null)
      {
        builder.Invoke(context);
      }

      // Register the generator used to apply the conventions
      AutoFaker.AddGeneratorOverride<string>(overrideContext =>
      {

      });
    }
  }
}
