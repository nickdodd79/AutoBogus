using System;
using System.Collections.Generic;

namespace AutoBogus.Tests.Models.Complex
{
  public sealed class Order : IWithCode
  {
    public DateTime Timestamp;
    
    public Order(int id, ICalculator calculator)
    {
      Id = id;
      Calculator = calculator;
    }

    public int Id { get; }
    public ICalculator Calculator { get; }
    public Guid? Code { get; set; }
    public Status Status { get; set; }
    public DiscountBase[] Discounts { get; set; }
    public IEnumerable<OrderItem> Items { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public ICollection<string> Comments { get; set; }
  }
}
