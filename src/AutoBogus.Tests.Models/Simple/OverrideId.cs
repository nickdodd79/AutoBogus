namespace AutoBogus.Tests.Models.Simple
{
  public sealed class OverrideId
  {
    public int Value { get; private set; }

    public void SetValue(int value)
    {
      Value = value;
    }
  }
}
