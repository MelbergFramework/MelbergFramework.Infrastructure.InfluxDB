using LightBDD.Framework.Scenarios;
using LightBDD.MsTest3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Features;

[TestClass]
public partial class InfluxTests : BaseTestFrame
{

    [Scenario]
    [TestMethod]
    public async Task This_literally_does_one_thing()
    {
        await Runner.RunScenarioAsync(
            _ => Write_to_database(),
            _ => Things_where_written()
        );
    }
}
