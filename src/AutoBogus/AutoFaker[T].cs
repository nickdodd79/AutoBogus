using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoBogus
{
  /// <summary>
  /// A class used to invoke generation requests of type <typeparamref name="TType"/>.
  /// </summary>
  /// <typeparam name="TType">The type of instance to generate.</typeparam>
  public class AutoFaker<TType>
    : Faker<TType>
    where TType : class
  {
    /// <summary>
    /// Instantiates an instance of the <see cref="AutoFaker{TType}"/> class.
    /// </summary>
    public AutoFaker()
      : this(null, null)
    { }

    /// <summary>
    /// Instantiates an instance of the <see cref="AutoFaker{TType}"/> class.
    /// </summary>
    /// <param name="locale">The locale to use for value generation.</param>
    public AutoFaker(string locale)
      : this(locale, null)
    { }

    /// <summary>
    /// Instantiates an instance of the <see cref="AutoFaker{TType}"/> class.
    /// </summary>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use for the generation request.</param>
    public AutoFaker(IAutoBinder binder)
      : this(null, binder)
    { }

    /// <summary>
    /// Instantiates an instance of the <see cref="AutoFaker{TType}"/> class.
    /// </summary>
    /// <param name="locale">The locale to use for value generation.</param>
    /// <param name="binder">The <see cref="IAutoBinder"/> instance to use for the generation request.</param>
    public AutoFaker(string locale = null, IAutoBinder binder = null)
      : base(locale ?? AutoFaker.DefaultLocale)
    {
      Binder = binder ?? AutoFaker.DefaultBinder;

      // Ensure the default create action is cleared
      // This is so we can check whether it has been set externally
      DefaultCreateAction = CreateActions[currentRuleSet];
      CreateActions[currentRuleSet] = null;
    }

    private Type Type => typeof(TType);

    internal IAutoBinder Binder { get; }

    private bool CreateInitialized { get; set; }
    private bool FinishInitialized { get; set; }
    private Func<Faker, TType> DefaultCreateAction { get; set; }
        
    /// <summary>
    /// Generates an instance of type <typeparamref name="TType"/>.
    /// </summary>
    /// <param name="ruleSets">An optional list of delimited rule sets to use for the generate request.</param>
    /// <returns>The generated instance of type <typeparamref name="TType"/>.</returns>
    public override TType Generate(string ruleSets = null)
    {
      var context = CreateContext<TType>(ruleSets);

      PrepareCreate(context);
      PrepareFinish(context);

      return base.Generate(ruleSets);
    }

    /// <summary>
    /// Generates a collection of instances of type <typeparamref name="TType"/>.
    /// </summary>
    /// <param name="count">The number of instances to generate.</param>
    /// <param name="ruleSets">An optional list of delimited rule sets to use for the generate request.</param>
    /// <returns>The collection of generated instances of type <typeparamref name="TType"/>.</returns>
    public override List<TType> Generate(int count, string ruleSets = null)
    {
      var context = CreateContext<List<TType>>(ruleSets);

      PrepareCreate(context);
      PrepareFinish(context);

      return base.Generate(count, ruleSets);
    }    

    /// <summary>
    /// Populates the provided instance with auto generated values.
    /// </summary>
    /// <param name="instance">The instance to populate.</param>
    /// <param name="ruleSets">An optional list of delimited rule sets to use for the populate request.</param>
    public override void Populate(TType instance, string ruleSets = null)
    {
      var context = CreateContext<TType>(ruleSets);

      PrepareFinish(context);

      base.Populate(instance, ruleSets);
    }
    
    private AutoGenerateContext CreateContext<TGenerate>(string ruleSets)
    {
      var type = typeof(TGenerate);
      var ruleSetNames = ParseRuleSets(ruleSets);

      return new AutoGenerateContext(type, FakerHub, ruleSetNames, Binder);
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
            return Binder.CreateInstance<TType>(context);
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
