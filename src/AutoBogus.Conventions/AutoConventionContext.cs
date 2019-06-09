namespace AutoBogus.Conventions
{
  internal sealed class AutoConventionContext
  {
    internal AutoConventionContext(AutoConventionConfig config, AutoGenerateOverrideContext context)
    {
      Config = config;
      OverrideContext = context;
    }

    internal object Instance { get; set; }

    internal AutoConventionConfig Config { get; }
    internal AutoGenerateOverrideContext OverrideContext { get; }
  }
}
