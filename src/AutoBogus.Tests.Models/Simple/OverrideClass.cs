namespace AutoBogus.Tests.Models.Simple
{
  public class OverrideClass
  {
    public OverrideClass()
    {
      Id = new OverrideIdClass();
    }

    public OverrideIdClass Id { get; }
    public OverrideClass Child { get; set; }
  }
}
