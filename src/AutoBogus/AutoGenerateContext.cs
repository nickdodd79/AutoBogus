using Bogus;
using System.Collections.Generic;

namespace AutoBogus
{
  public sealed class AutoGenerateContext
  {
    private const int DefaultCount = 3;

    internal AutoGenerateContext(Faker faker, IEnumerable<string> ruleSets, IAutoBinder binder)
    {
      Faker = faker;
      RuleSets = ruleSets;
      Binder = binder;
    }
    
    public Faker Faker { get; }
    public IEnumerable<string> RuleSets { get; }

    internal IAutoBinder Binder { get; }

    public TType Generate<TType>(AutoGenerateContext context)
    {
      var generator = AutoGeneratorFactory.GetGenerator<TType>(context);
      return (TType)generator.Generate(context);
    }

    public IEnumerable<TType> GenerateMany<TType>(AutoGenerateContext context)
    {
      var items = new List<TType>();

      for (var index = 0; index < DefaultCount; index++)
      {
        var item = Generate<TType>(context);

        // Ensure the generated value is not null (which means the type couldn't be generated)
        if (item != null)
        {
          items.Add(item);
        }
      }

      return items;
    }
  }
}
