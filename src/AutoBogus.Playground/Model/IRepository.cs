using System;
using System.Collections.Generic;

namespace AutoBogus.Playground.Model
{
  public interface IRepository
  {
    Item Get(Guid id);
    IEnumerable<Item> GetAll();
    IEnumerable<Item> GetFiltered(Func<Item, bool> filter);
  }
}
