using AutoBogus.Generators;
using AutoBogus.NSubstitute;
using Bogus;
using FluentAssertions;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoConfigBuilderFixture
  {
    private Faker _faker;
    private AutoConfig _config;
    private AutoConfigBuilder _builder;

    private interface ITestBuilder { }

    public AutoConfigBuilderFixture()
    {
      _faker = new Faker();
      _config = new AutoConfig();
      _builder = new AutoConfigBuilder(_config);
    }

    public class WithLocale
      : AutoConfigBuilderFixture
    {
      [Fact]
      public void Should_Set_Config_Locale()
      {
        var locale = _faker.Random.String();

        _builder.WithLocale<ITestBuilder>(locale, null);

        _config.Locale.Should().Be(locale);
      }

      [Fact]
      public void Should_Set_Config_Locale_To_Default_If_Null()
      {
        _config.Locale = _faker.Random.String();

        _builder.WithLocale<ITestBuilder>(null, null);

        _config.Locale.Should().Be(AutoConfig.DefaultLocale);
      }
    }

    public class WithRepeatCount
      : AutoConfigBuilderFixture
    {
      [Fact]
      public void Should_Set_Config_RepeatCount()
      {
        var count = _faker.Random.Int();

        _builder.WithRepeatCount<ITestBuilder>(count, null);

        _config.RepeatCount.Should().Be(count);
      }
    }

    public class WithRecursiveDepth
      : AutoConfigBuilderFixture
    {
      [Fact]
      public void Should_Set_Config_RecursiveDepth()
      {
        var depth = _faker.Random.Int();

        _builder.WithRecursiveDepth<ITestBuilder>(depth, null);

        _config.RecursiveDepth.Should().Be(depth);
      }
    }

    public class WithBinder
      : AutoConfigBuilderFixture
    {
      [Fact]
      public void Should_Set_Config_Binder()
      {
        var binder = new NSubstituteBinder();

        _builder.WithBinder<ITestBuilder>(binder, null);

        _config.Binder.Should().Be(binder);
      }

      [Fact]
      public void Should_Set_Config_Binder_To_Default_If_Null()
      {
        _config.Binder = new NSubstituteBinder();

        _builder.WithBinder<ITestBuilder>(null, null);

        _config.Binder.Should().BeOfType<AutoBinder>();
      }
    }

    public class WithOverride
      : AutoConfigBuilderFixture
    {
      private class TestGeneratorOverride
        : AutoGeneratorOverride
      {
        public override bool CanOverride(AutoGenerateContext context)
        {
          return false;
        }
      }

      [Fact]
      public void Should_Not_Add_Null_Override()
      {
        _builder.WithOverride<ITestBuilder>(null, null);

        _config.Overrides.Should().BeEmpty();
      }

      [Fact]
      public void Should_Not_Add_Override_If_Already_Added()
      {
        var generatorOverride = new TestGeneratorOverride();
        _config.Overrides.Add(generatorOverride);

        _builder.WithOverride<ITestBuilder>(generatorOverride, null);

        _config.Overrides.Should().ContainSingle();
      }

      [Fact]
      public void Should_Add_Override_If_Equivalency_Is_Different()
      {
        var generatorOverride1 = new TestGeneratorOverride() { ResolvedGenerator = new IntGenerator() };
        var generatorOverride2 = new TestGeneratorOverride() { ResolvedGenerator = new StringGenerator() };

        _config.Overrides.Add(generatorOverride1);

        _builder.WithOverride<ITestBuilder>(generatorOverride2, null);

        _config.Overrides.Should().BeEquivalentTo(new[]
        {
          generatorOverride1,
          generatorOverride2
        });
      }
    }

    public class WithArgs
      : AutoConfigBuilderFixture
    {
      [Fact]
      public void Should_Set_Args()
      {
        var args = new object[] { _faker.Random.Int(), _faker.Random.String() };

        _builder.WithArgs<ITestBuilder>(args, null);

        _builder.Args.Should().BeSameAs(args);
      }
    }
  }
}
