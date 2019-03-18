using AutoBogus.Conventions;
using System;
using Xunit;

namespace AutoBogus.Tests
{
  public class AutoConventionsFixture
    : IDisposable
  {
    private class TestClass
    {
      public string FirstName { get; set; }
      public string Byname { get; set; }
      public string FullName { get; set; }
    }

    public AutoConventionsFixture()
    {
      AutoFaker.SetGeneratorOverrides(
        new AutoGeneratorConventionsOverride());
    }

    public void Dispose()
    {
      AutoFaker.SetGeneratorOverrides();
    }

    [Fact]
    public void Should_Apply_Conventions()
    {
      var instance = AutoFaker.Generate<TestClass>();
    }
  }
}
