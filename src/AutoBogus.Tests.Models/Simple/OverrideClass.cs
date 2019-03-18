using System.Collections.Generic;

namespace AutoBogus.Tests.Models.Simple
{
  public sealed class OverrideClass
  {
    public OverrideClass()
    {
      Id = new OverrideId();
    }

    public OverrideId Id { get; }
    public string Name { get; set; }
    public IEnumerable<int> Amounts { get; set; }
  }
}