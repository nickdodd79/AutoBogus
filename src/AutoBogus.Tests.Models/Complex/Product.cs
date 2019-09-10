using System;
using System.Collections.Generic;

namespace AutoBogus.Tests.Models.Complex
{
  public class Product
  {
    private readonly IList<DateTime> _revisions = new List<DateTime>();

    public Product(int id)
    {
      Id = id;
      Reviews = new Dictionary<int, string>();
    }

    public int Id { get; }
    public string Description { get; set; }
    public Price Price { get; set; }
    public Uri ImageUrl { get; set; }
    public IDictionary<int, string> Reviews { get; }

    protected ICollection<DateTime> Revisions => _revisions;
  }
}


