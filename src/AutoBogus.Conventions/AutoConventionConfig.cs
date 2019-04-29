namespace AutoBogus.Conventions
{
  public sealed class AutoConventionConfig
  {
    internal AutoConventionConfig()
    {
      AlwaysGenerate = true;
    }

    public bool AlwaysGenerate { get; set; }
  }
}
