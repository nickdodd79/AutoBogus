using Bogus;
using System;

namespace AutoBogus
{
  /// <summary>
  /// A class that provides context for an overridden generate request.
  /// </summary>
  public sealed class AutoGeneratorOverrideContext
  {
    internal AutoGeneratorOverrideContext(AutoGenerateContext context)
    {
      Faker = context.Faker;
      MemberName = context.MemberName;
      MemberType = context.MemberType;
      Populate = true;
    }

    /// <summary>
    /// The underlying <see cref="Bogus.Faker"/> instance used to generate random values.
    /// </summary>
    public Faker Faker { get; }

    /// <summary>
    /// The name of the member currently being generated.
    /// </summary>
    public string MemberName { get; }
    
    /// <summary>
    /// The <see cref="Type"/> of the member currently being generated.
    /// </summary>
    public Type MemberType { get; }

    /// <summary>
    /// Whether the generated value should continue to be populated. Defaults to true.
    /// </summary>
    public bool Populate { get; set; }
  }
}
