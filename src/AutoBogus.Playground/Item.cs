using System;

namespace AutoBogus.Playground
{
  public sealed class Item
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public uint Quantity { get; set; }
    public Units Units { get; set; }
  }
}
