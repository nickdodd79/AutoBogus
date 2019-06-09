namespace AutoBogus.Conventions
{
  internal interface IAutoConventionGenerator
  {
    bool Enabled(AutoConventionConfig config);

    bool CanGenerate(AutoGenerateContext context);

    object Generate(AutoConventionContext context);
  }
}
