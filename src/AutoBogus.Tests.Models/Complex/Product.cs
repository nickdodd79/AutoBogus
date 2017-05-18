namespace AutoBogus.Tests.Models.Complex
{
  public sealed class Product
  {
    public Product(int id)
    {
      Id = id;
    }

    public int Id { get; }
    public string Description { get; set; }
    public Price Price { get; set; }
  }
}
