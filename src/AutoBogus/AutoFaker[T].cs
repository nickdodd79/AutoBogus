using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoBogus
{
  public sealed class AutoFaker<TType>
    : Faker<TType>
    where TType : class
  {
    public AutoFaker()
      : this("en", null)
    { }

    public AutoFaker(string locale)
      : this(locale, null)
    { }

    public AutoFaker(IAutoBinder binder)
      : this(null, binder)
    { }

    public AutoFaker(string locale = "en", IAutoBinder binder = null)
      : this(new AutoFakerContext(locale, binder))
    { }

    private AutoFaker(AutoFakerContext context)
      : base(context.Locale, context.Binder)
    {
      Context = context;

      // Ensure the default create action is cleared
      // This is so we can check whether it has been set externally
      DefaultCreateAction = CreateActions[currentRuleSet];
      CreateActions[currentRuleSet] = null;
    }

    private Type Type => typeof(TType);

    private AutoFakerContext Context { get; }

    private bool CreateInitialized { get; set; }
    private bool FinishInitialized { get; set; }
    private Func<Faker, TType> DefaultCreateAction { get; set; }

    public override TType Generate(string ruleSets = null)
    {
      var context = GetContext(ruleSets);

      PrepareCreate(context);
      PrepareFinish(context);

      return base.Generate(ruleSets);
    }

    public override IEnumerable<TType> Generate(int count, string ruleSets = null)
    {
      var context = GetContext(ruleSets);

      PrepareCreate(context);
      PrepareFinish(context);

      return base.Generate(count, ruleSets);
    }

    public override void Populate(TType instance, string ruleSets = null)
    {
      var context = GetContext(ruleSets);

      PrepareFinish(context);

      base.Populate(instance, ruleSets);
    }
    
    private AutoGenerateContext GetContext(string ruleSets)
    {
      var type = typeof(TType);
      var ruleSetNames = ParseRuleSets(ruleSets);

      return new AutoGenerateContext(FakerHub, ruleSetNames, Context.Binder);
    }

    private IEnumerable<string> ParseRuleSets(string ruleSets)
    {
      // Parse and clean the rule set list
      // If the rule set list is empty it defaults to a list containing only 'default'
      // By this point the currentRuleSet should be 'default'
      if (string.IsNullOrWhiteSpace(ruleSets))
      {
        ruleSets = null;
      }

      return (from ruleSet in ruleSets?.Split(',') ?? new[] { currentRuleSet }
              where !string.IsNullOrWhiteSpace(ruleSet)
              select ruleSet.Trim());
    }

    private void PrepareCreate(AutoGenerateContext context)
    {
      // Check a create handler hasn't previously been set or configured externally
      if (!CreateInitialized && CreateActions[currentRuleSet] == null)
      {
        CreateActions[currentRuleSet] = faker =>
        {
          // Only auto create if the 'default' rule set is defined for generation
          // This is because any specific rule sets are expected to handle the full creation
          if (context.RuleSets.Contains(currentRuleSet))
          {
            return Context.Binder.CreateInstance<TType>(context);
          }

          return DefaultCreateAction.Invoke(faker);
        };

        CreateInitialized = true;
      }
    }

    private void PrepareFinish(AutoGenerateContext context)
    {
      if (!FinishInitialized)
      {
        FinishWith((faker, instance) =>
        {
          // First resolve the values being set
          // This is from all the rule sets being used to generate the instance
          var memberNames = new List<string>();

          foreach (var ruleSetName in context.RuleSets)
          {
            if (Actions.TryGetValue(ruleSetName, out var ruleSet))
            {
              memberNames.AddRange(ruleSet.Keys);
            }
          }

          // Extract the unpopulated member infos
          var members = new List<MemberInfo>();

          foreach (var member in TypeProperties)
          {
            if (!memberNames.Contains(member.Key))
            {
              members.Add(member.Value);
            }
          }

          // Finalize the instance population
          context.Binder.PopulateInstance<TType>(instance, context, members);
        });

        FinishInitialized = true;
      }
    }
  }
}
