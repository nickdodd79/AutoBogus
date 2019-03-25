using System.Linq;

namespace AutoBogus
{
  internal sealed class AutoConfigBuilder
    : IAutoFakerDefaultConfigBuilder, IAutoGenerateConfigBuilder, IAutoFakerConfigBuilder
  {
    internal AutoConfigBuilder(AutoConfig config)
    {
      Config = config;
    }

    private AutoConfig Config { get; }

    internal object[] Args { get; private set; }

    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithLocale(string locale) => WithLocale<IAutoFakerDefaultConfigBuilder>(locale, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithRepeatCount(int count) => WithRepeatCount<IAutoFakerDefaultConfigBuilder>(count, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithRecursiveDepth(int depth) => WithRecursiveDepth<IAutoFakerDefaultConfigBuilder>(depth, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithBinder<TBinder>() => WithBinder<TBinder, IAutoFakerDefaultConfigBuilder>(this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithBinder(IAutoBinder binder) => WithBinder<IAutoFakerDefaultConfigBuilder>(binder, this);
    IAutoFakerDefaultConfigBuilder IAutoConfigBuilder<IAutoFakerDefaultConfigBuilder>.WithOverride(AutoGeneratorOverride generatorOverride) => WithOverride<IAutoFakerDefaultConfigBuilder>(generatorOverride, this);

    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithLocale(string locale) => WithLocale<IAutoGenerateConfigBuilder>(locale, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithRepeatCount(int count) => WithRepeatCount<IAutoGenerateConfigBuilder>(count, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithRecursiveDepth(int depth) => WithRecursiveDepth<IAutoGenerateConfigBuilder>(depth, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithBinder<TBinder>() => WithBinder<TBinder, IAutoGenerateConfigBuilder>(this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithBinder(IAutoBinder binder) => WithBinder<IAutoGenerateConfigBuilder>(binder, this);
    IAutoGenerateConfigBuilder IAutoConfigBuilder<IAutoGenerateConfigBuilder>.WithOverride(AutoGeneratorOverride generatorOverride) => WithOverride<IAutoGenerateConfigBuilder>(generatorOverride, this);

    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithLocale(string locale) => WithLocale<IAutoFakerConfigBuilder>(locale, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithRepeatCount(int count) => WithRepeatCount<IAutoFakerConfigBuilder>(count, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithRecursiveDepth(int depth) => WithRecursiveDepth<IAutoFakerConfigBuilder>(depth, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithBinder<TBinder>() => WithBinder<TBinder, IAutoFakerConfigBuilder>(this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithBinder(IAutoBinder binder) => WithBinder<IAutoFakerConfigBuilder>(binder, this);
    IAutoFakerConfigBuilder IAutoConfigBuilder<IAutoFakerConfigBuilder>.WithOverride(AutoGeneratorOverride generatorOverride) => WithOverride<IAutoFakerConfigBuilder>(generatorOverride, this);
    IAutoFakerConfigBuilder IAutoFakerConfigBuilder.WithArgs(params object[] args) => WithArgs<IAutoFakerConfigBuilder>(args, this);

    private TBuilder WithLocale<TBuilder>(string locale, TBuilder builder)
    {
      Config.Locale = locale ?? AutoConfig.DefaultLocale;
      return builder;
    }

    private TBuilder WithRepeatCount<TBuilder>(int count, TBuilder builder)
    {
      Config.RepeatCount = count;
      return builder;
    }

    private TBuilder WithRecursiveDepth<TBuilder>(int depth, TBuilder builder)
    {
      Config.RecursiveDepth = depth;
      return builder;
    }

    private TBuilder WithBinder<TBinder, TBuilder>(TBuilder builder)
      where TBinder : IAutoBinder, new()
    {
      var binder = new TBinder();
      return WithBinder(binder, builder);
    }

    private TBuilder WithBinder<TBuilder>(IAutoBinder binder, TBuilder builder)
    {
      Config.Binder = binder ?? new AutoBinder(); ;
      return builder;
    }

    private TBuilder WithOverride<TBuilder>(AutoGeneratorOverride generatorOverride, TBuilder builder)
    {
      if (generatorOverride != null)
      {
        var existing = Config.Overrides.Any(o => o.GetType() == generatorOverride.GetType());

        if (!existing)
        {
          Config.Overrides.Add(generatorOverride);
        }
      }

      return builder;
    }

    private TBuilder WithArgs<TBuilder>(object[] args, TBuilder builder)
    {
      Args = args;
      return builder;
    }
  }
}
