using Bogus;

namespace AutoBogus
{
  /// <summary>
  /// A class that provides context for an overridden generate request.
  /// </summary>
  public sealed class AutoGeneratorOverrideContext
  {
    internal AutoGeneratorOverrideContext(Faker faker)
    {
      Faker = faker;
      Populate = true;
    }

    /// <summary>
    /// The underlying <see cref="Bogus.Faker"/> instance used to generate random values.
    /// </summary>
    public Faker Faker { get; }

    /// <summary>
    /// Whether the generated value should continue to be populated. Defaults to true.
    /// </summary>
    public bool Populate { get; set; }
  }
}
