namespace AutoBogus.Conventions
{
  internal interface IAutoConventionGenerator
  {
    bool CanGenerate(AutoConventionConfig config, AutoGenerateContext context);

    object Generate(AutoConventionContext context);
  }
}
