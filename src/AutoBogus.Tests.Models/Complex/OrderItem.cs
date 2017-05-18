using System.Collections.Generic;

namespace AutoBogus.Tests.Models.Complex
{
  public sealed class OrderItem
  {
    public OrderItem(Product product)
    {
      Product = product;
    }

    public Product Product { get; }
    public Quantity Quantity { get; set; }  
    public IDictionary<int, decimal> Discounts { get; set; }
  }
}
