using AutoBogus.Util;
using Bogus;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AutoBogus
{
  internal sealed class AutoConfigBuilder
    : IAutoFakerDefaultConfigBuilder, IAutoGenerateConfigBuilder, IAutoFakerConfigBuilder
  {
    internal AutoConfigBuilder(AutoConfig config)
    {
      Config = config;
    }

    internal AutoConfig Config { get; }

    internal object[] Args { get; private set; }

    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithLocale(string locale) => WithLocale<IAutoFakerDefaultConfigBuilder>(locale, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithRepeatCount(int count) => WithRepeatCount<IAutoFakerDefaultConfigBuilder>(count, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithRecursiveDepth(int depth) => WithRecursiveDepth<IAutoFakerDefaultConfigBuilder>(depth, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithBinder(IAutoBinder binder) => WithBinder<IAutoFakerDefaultConfigBuilder>(binder, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithFakerHub(Faker fakerHub) => WithFakerHub<IAutoFakerDefaultConfigBuilder>(fakerHub, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithSkip<TType>(string memberName) => WithSkip<IAutoFakerDefaultConfigBuilder, TType>(memberName, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithSkip<TType>(Expression<Func<TType, object>> member) => WithSkip<IAutoFakerDefaultConfigBuilder, TType>(member, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithOverride(AutoGeneratorOverride generatorOverride) => WithOverride<IAutoFakerDefaultConfigBuilder>(generatorOverride, this);
    
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithLocale(string locale) => WithLocale<IAutoGenerateConfigBuilder>(locale, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithRepeatCount(int count) => WithRepeatCount<IAutoGenerateConfigBuilder>(count, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithRecursiveDepth(int depth) => WithRecursiveDepth<IAutoGenerateConfigBuilder>(depth, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithBinder(IAutoBinder binder) => WithBinder<IAutoGenerateConfigBuilder>(binder, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithFakerHub(Faker fakerHub) => WithFakerHub<IAutoGenerateConfigBuilder>(fakerHub, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithSkip<TType>(string memberName) => WithSkip<IAutoGenerateConfigBuilder, TType>(memberName, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithSkip<TType>(Expression<Func<TType, object>> member) => WithSkip<IAutoGenerateConfigBuilder, TType>(member, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithOverride(AutoGeneratorOverride generatorOverride) => WithOverride<IAutoGenerateConfigBuilder>(generatorOverride, this);
    
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithLocale(string locale) => WithLocale<IAutoFakerConfigBuilder>(locale, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithRepeatCount(int count) => WithRepeatCount<IAutoFakerConfigBuilder>(count, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithRecursiveDepth(int depth) => WithRecursiveDepth<IAutoFakerConfigBuilder>(depth, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithBinder(IAutoBinder binder) => WithBinder<IAutoFakerConfigBuilder>(binder, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithFakerHub(Faker fakerHub) => WithFakerHub<IAutoFakerConfigBuilder>(fakerHub, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithSkip<TType>(string memberName) => WithSkip<IAutoFakerConfigBuilder, TType>(memberName, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithSkip<TType>(Expression<Func<TType, object>> member) => WithSkip<IAutoFakerConfigBuilder, TType>(member, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithOverride(AutoGeneratorOverride generatorOverride) => WithOverride<IAutoFakerConfigBuilder>(generatorOverride, this);
    IAutoFakerConfigBuilder IAutoFakerConfigBuilder.WithArgs(params object[] args) => WithArgs<IAutoFakerConfigBuilder>(args, this);

    internal TBuilder WithLocale<TBuilder>(string locale, TBuilder builder)
    {
      Config.Locale = locale ?? AutoConfig.DefaultLocale;
      return builder;
    }

    internal TBuilder WithRepeatCount<TBuilder>(int count, TBuilder builder)
    {
      Config.RepeatCount = count;
      return builder;
    }

    internal TBuilder WithRecursiveDepth<TBuilder>(int depth, TBuilder builder)
    {
      Config.RecursiveDepth = depth;
      return builder;
    }

    internal TBuilder WithBinder<TBuilder>(IAutoBinder binder, TBuilder builder)
    {
      Config.Binder = binder ?? new AutoBinder();
      return builder;
    }

    internal TBuilder WithFakerHub<TBuilder>(Faker fakerHub, TBuilder builder)
    {
      Config.FakerHub = fakerHub;
      return builder;
    }

    internal TBuilder WithSkip<TBuilder, TType>(Expression<Func<TType, object>> member, TBuilder builder)
    {
      var memberName = GetMemberName(member);
      return WithSkip<TBuilder, TType>(memberName, builder);
    }

    internal TBuilder WithSkip<TBuilder, TType>(string memberName, TBuilder builder)
    { 
      var type = typeof(TType);

      if (!string.IsNullOrWhiteSpace(memberName))
      {
        var path = $"{type.FullName}.{memberName}";
        var existing = Config.Skips.Any(s => s == path);

        if (!existing)
        {
          Config.Skips.Add(path);
        }
      }

      return builder;
    }

    internal TBuilder WithOverride<TBuilder>(AutoGeneratorOverride generatorOverride, TBuilder builder)
    {
      if (generatorOverride != null)
      {
        var existing = Config.Overrides.Any(o => o == generatorOverride);

        if (!existing)
        {
          Config.Overrides.Add(generatorOverride);
        }
      }

      return builder;
    }

    internal TBuilder WithArgs<TBuilder>(object[] args, TBuilder builder)
    {
      Args = args;
      return builder;
    }

    private string GetMemberName<TType>(Expression<Func<TType, object>> member)
    {
      if (member != null)
      {
        MemberExpression expression;

        if (member.Body is UnaryExpression unary)
        {
          expression = unary.Operand as MemberExpression;
        }
        else
        {
          expression = member.Body as MemberExpression;
        }

        if (expression != null)
        {
          var memberInfo = expression.Member;

          if (ReflectionHelper.IsField(memberInfo) || ReflectionHelper.IsProperty(memberInfo))
          {
            return memberInfo.Name;
          }
        }
      }

      return null;     
    }
  }
}
