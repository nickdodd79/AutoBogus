using AutoBogus.NSubstitute;
using Bogus;
using FluentAssertions;
using System;
using System.Linq.Expressions;
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

        _builder.WithRepeatCount<ITestBuilder>(context => count, null);

        _config.RepeatCount.Invoke(null).Should().Be(count);
      }

      [Fact]
      public void Should_Set_Config_RepeatCount_To_Default_If_Null()
      {
        var count = AutoConfig.DefaultRepeatCount.Invoke(null);

        _builder.WithRepeatCount<ITestBuilder>(null, null);

        _config.RepeatCount.Invoke(null).Should().Be(count);
      }
    }

    public class WithRecursiveDepth
      : AutoConfigBuilderFixture
    {
      [Fact]
      public void Should_Set_Config_RecursiveDepth()
      {
        var depth = _faker.Random.Int();

        _builder.WithRecursiveDepth<ITestBuilder>(context => depth, null);

        _config.RecursiveDepth.Invoke(null).Should().Be(depth);
      }

      [Fact]
      public void Should_Set_Config_RecursiveDepth_To_Default_If_Null()
      {
        var depth = AutoConfig.DefaultRecursiveDepth.Invoke(null);

        _builder.WithRecursiveDepth<ITestBuilder>(null, null);

        _config.RecursiveDepth.Invoke(null).Should().Be(depth);
      }
    }

    
    public class WithTreeDepth
      : AutoConfigBuilderFixture
    {
      [Fact]
      public void Should_Set_Config_TreeDepth()
      {
        var depth = _faker.Random.Int();

        _builder.WithTreeDepth<ITestBuilder>(context => depth, null);

        _config.TreeDepth.Invoke(null).Should().Be(depth);
      }

      [Fact]
      public void Should_Set_Config_TreeDepth_To_Default_If_Null()
      {
        var depth = AutoConfig.DefaultTreeDepth.Invoke(null);

        _builder.WithTreeDepth<ITestBuilder>(null, null);

        _config.TreeDepth.Invoke(null).Should().Be(depth);
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

    public class WithFakerHub
      : AutoConfigBuilderFixture
    {
      [Fact]
      public void Should_Set_Config_FakerHub()
      {
        var fakerHub = new Faker();

        _builder.WithFakerHub<ITestBuilder>(fakerHub, null);

        _config.FakerHub.Should().Be(fakerHub);
      }
    }

    public class WithSkip_Type
      : AutoConfigBuilderFixture
    {
      [Fact]
      public void Should_Not_Add_Type_If_Already_Added()
      {
        var type1 = typeof(int);
        var type2 = typeof(int);

        _config.SkipTypes.Add(type1);

        _builder.WithSkip<ITestBuilder>(type2, null);

        _config.SkipTypes.Should().ContainSingle();
      }

      [Fact]
      public void Should_Add_Type_To_Skip()
      {
        var type1 = typeof(int);
        var type2 = typeof(string);

        _config.SkipTypes.Add(type1);

        _builder.WithSkip<ITestBuilder>(type2, null);

        _config.SkipTypes.Should().BeEquivalentTo(new[]
        {
          type1,
          type2
        });
      }
    }

    public class WithSkip_TypePath
      : AutoConfigBuilderFixture
    {
      private sealed class TestSkip
      {
        public string Value { get; set; }
      }

      [Fact]
      public void Should_Not_Add_Member_If_Already_Added()
      {
        var type = typeof(TestSkip);
        var member = $"{type.FullName}.Value";

        _config.SkipPaths.Add(member);

        _builder.WithSkip<ITestBuilder>(type, "Value", null);

        _config.SkipPaths.Should().ContainSingle();
      }

      [Fact]
      public void Should_Add_MemberName_To_Skip()
      {
        var type = typeof(TestSkip);
        var path = _faker.Random.String();

        _config.SkipPaths.Add(path);

        _builder.WithSkip<ITestBuilder>(type, "Value", null);

        _config.SkipPaths.Should().BeEquivalentTo(new[]
        {
          path,
          $"{type.FullName}.Value"
        });
      }
    }

    public class WithSkip_Path
      : AutoConfigBuilderFixture
    {
      private sealed class TestSkip
      {
        public string Value { get; set; }
      }

      [Fact]
      public void Should_Not_Add_Member_If_Already_Added()
      {
        var type = typeof(TestSkip);
        var member = $"{type.FullName}.Value";

        _config.SkipPaths.Add(member);

        _builder.WithSkip<ITestBuilder, TestSkip>("Value", null);

        _config.SkipPaths.Should().ContainSingle();
      }

      [Fact]
      public void Should_Add_MemberName_To_Skip()
      {
        var type = typeof(TestSkip);
        var path = _faker.Random.String();

        _config.SkipPaths.Add(path);

        _builder.WithSkip<ITestBuilder, TestSkip>("Value", null);

        _config.SkipPaths.Should().BeEquivalentTo(new[]
        {
          path,
          $"{type.FullName}.Value"
        });
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

        public override void Generate(AutoGenerateOverrideContext context)
        { }
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
        var generatorOverride1 = new TestGeneratorOverride();
        var generatorOverride2 = new TestGeneratorOverride();

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
