using AutoBogus.NSubstitute;
using AutoBogus.Playground.Model;

namespace AutoBogus.Playground
{
  public abstract class FixtureBase
  {
    private class ProductGeneratorOverride
      : AutoGeneratorOverride
    {
      public override bool CanOverride(AutoGenerateContext context)
      {
        return context.GenerateType.IsGenericType &&
               context.GenerateType.GetGenericTypeDefinition() == typeof(Product<>);
      }

      public override void Generate(AutoGenerateOverrideContext context)
      {
        base.Generate(context);

        // Get the code and apply a serial number value
        var serialNumber = AutoFaker.Generate<string>();
        var codeProperty = context.GenerateType.GetProperty("Code");
        var codeInstance = codeProperty.GetValue(context.Instance);
        var serialNumberProperty = codeProperty.PropertyType.GetProperty("SerialNumber");

        serialNumberProperty.SetValue(codeInstance, serialNumber);
      }
    }

    public FixtureBase()
    {
      Faker = AutoFaker.Create(builder =>
      {
        builder
          .WithBinder<NSubstituteBinder>()
          .WithOverride(new ProductGeneratorOverride());
      });
    }

    protected IAutoFaker Faker { get; }
  }
}
