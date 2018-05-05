using System.Collections.Generic;

namespace AutoBogus.Playground
{
  public interface IRepository
  {
    IEnumerable<Item> GetAll();
  }
}
