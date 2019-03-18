namespace AutoBogus.Playground.Model
{
  public sealed class Product<TId>
  {
    public Product()
    {
      Code = new ProductCode();
    }

    public TId Id { get; set; }
    public ProductCode Code { get; }
    public string Name { get; set; }
    public Product<TId> Parent { get; set; }
  }
}
