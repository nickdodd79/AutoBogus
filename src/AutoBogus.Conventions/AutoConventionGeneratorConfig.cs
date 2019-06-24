using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBogus.Conventions
{
  /// <summary>
  /// A class for configuring conventions for a generator.
  /// </summary>
  public sealed class AutoConventionGeneratorConfig
  {
    private readonly string _name;
    private IEnumerable<string> _aliases;

    internal AutoConventionGeneratorConfig(string name)
    {
      Enabled = true;
      AlwaysGenerate = true;

      _name = name;

      SetAliases();
    }

    /// <summary>
    /// Whether the generator is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Whether values should always be generated, even is already assigned.
    /// </summary>
    public bool AlwaysGenerate { get; set; }

    /// <summary>
    /// Adds custom aliases for a generator.
    /// </summary>
    /// <param name="aliases">The collection of aliases.</param>
    public void Aliases(params string[] aliases)
    {
      var filtered = aliases
        .Where(alias => !string.IsNullOrWhiteSpace(alias))
        .ToArray();

      SetAliases(filtered);
    }

    internal bool HasAlias(string name)
    {
      return _aliases.Any(alias => alias.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    private void SetAliases(params string[] aliases)
    {
      _aliases = new List<string>(aliases)
      {
        _name
      };
    }
  }
}
