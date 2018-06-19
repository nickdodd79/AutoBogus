using System;
using System.Collections.Generic;

namespace AutoBogus.Playground
{
  public sealed class Item
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public uint Quantity { get; set; }
    public Units Units { get; set; }
    public ItemStatus Status { get; set; }
    public ICollection<string> Comments { get; set; }
  }
}
