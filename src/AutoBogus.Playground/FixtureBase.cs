using AutoBogus.NSubstitute;

namespace AutoBogus.Playground
{
  public abstract class FixtureBase
  {
    public FixtureBase()
    {
      Faker = AutoFaker.Create<NSubstituteBinder>();
    }

    protected IAutoFaker Faker { get; }
  }
}
