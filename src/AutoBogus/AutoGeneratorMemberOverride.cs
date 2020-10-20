using System;

namespace AutoBogus
{
  internal sealed class AutoGeneratorMemberOverride<TType, TValue>
    : AutoGeneratorOverride
  {
    internal AutoGeneratorMemberOverride(string memberName, Func<AutoGenerateOverrideContext, TValue> generator)
    {
      if (string.IsNullOrWhiteSpace(memberName))
      {
        throw new ArgumentException("Value cannot be null or white space", nameof(memberName));
      }

      Type = typeof(TType);
      MemberName = memberName;
      Generator = generator ?? throw new ArgumentNullException(nameof(generator));
    }

    private Type Type { get; }
    private string MemberName { get; }
    private Func<AutoGenerateOverrideContext, TValue> Generator { get; }

    public override bool CanOverride(AutoGenerateContext context)
    {
      return context.ParentType == Type && MemberName.Equals(context.GenerateName, StringComparison.OrdinalIgnoreCase);
    }

    public override void Generate(AutoGenerateOverrideContext context)
    {
      context.Instance = Generator.Invoke(context);
    }
  }
}
