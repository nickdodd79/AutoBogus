using System.Collections.Generic;

namespace AutoBogus.Playground
{
  public sealed class Service
    : FixtureBase
  {
    public Service(IRepository repository)
    {
      Repository = repository;
    }

    private IRepository Repository { get; }

    public IEnumerable<Item> GetAll()
    {      
      return Repository.GetAll();
    }
  }
}
