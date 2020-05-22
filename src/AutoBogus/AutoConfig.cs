using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace AutoBogus
{
  internal sealed class AutoConfig
  {
    internal const string DefaultLocale = "en";
    internal const int DefaultRepeatCount = 3;
    internal const int DefaultRecursiveCount = 2;
    internal const int GenerateAttemptsThreshold = 3;

    internal AutoConfig()
    {
      Locale = DefaultLocale;
      RepeatCount = DefaultRepeatCount;
      RecursiveDepth = DefaultRecursiveCount;
      Binder = new AutoBinder();
      Skips = new List<string>();
      Overrides = new List<AutoGeneratorOverride>();
    }

    internal AutoConfig(AutoConfig config)
    {
      Locale = config.Locale;
      RepeatCount = config.RepeatCount;
      RecursiveDepth = config.RecursiveDepth;
      Binder = config.Binder;
      FakerHub = config.FakerHub;
      Skips = config.Skips.ToList();
      Overrides = config.Overrides.ToList();
    }

    internal string Locale { get; set; }
    internal int RepeatCount { get; set; }
    internal int RecursiveDepth { get; set; }
    internal IAutoBinder Binder { get; set; }
    internal Faker FakerHub { get; set; }
    internal IList<string> Skips { get; set; }
    internal IList<AutoGeneratorOverride> Overrides { get; set; }
  }
}
