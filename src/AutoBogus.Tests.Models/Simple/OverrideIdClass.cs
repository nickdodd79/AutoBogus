namespace AutoBogus.Tests.Models.Simple
{
  public class OverrideIdClass
  {
    public int Value { get; private set; }

    public void Set(int value)
    {
      Value = value;
    }
  }
}
