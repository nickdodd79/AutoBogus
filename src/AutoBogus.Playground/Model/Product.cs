using System.Collections.Generic;

namespace AutoBogus.Playground.Model
{
  public class Product<TId>
  {
    public Product()
    {
      Code = new ProductCode();
    }

    public TId Id { get; set; }
    public ProductCode Code { get; }
    public string Name { get; set; }
    public Product<TId> Parent { get; set; }

    protected ICollection<string> Notes { get; } = new List<string>();
  }
}
