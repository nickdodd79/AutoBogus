using FluentAssertions;
using System.Collections.Generic;
using Xero.NetStandard.OAuth2.Model.Accounting;
using Xunit;

namespace AutoBogus.Playground
{

  public class XeroFixture
  {

    public class TestCreationPerformance
    {
      [Fact]
      public void TestAutoFakerXeroInvoice()
      {
        //previously this took > 45 seconds unless a lot of types were skipped
        AutoFaker.Configure(builder =>
        {
          builder.WithTreeDepth(1);
        });

        var fake = new AutoFaker<Invoice>();
        var created = fake.Generate();

        created.Should().NotBeNull();
      }

    }
  }
}
