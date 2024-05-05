using Application.Infrastructure;
using MelbergFramework.ComponentTesting.InfluxDB;
using MelbergFramework.Infrastructure.InfluxDB;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Features;

public partial class InfluxTests : BaseTestFrame
{
    public async Task Write_to_database()
    {
        var repo = GetClass<IDemoInfluxDBRepo>();

        await repo.DoThings();
    }

    public async Task Things_where_written()
    {
        var config = GetClass<IOptions<InfluxDBOptions<InfluxDBContext>>>();
        var context = GetClass<IStandardClientFactory>().GetClient(config.Value.Uri);
        var mockContext = (MockInfluxDBClient) context;

        Assert.AreEqual(1, mockContext.Written.Count);
        var written = mockContext.Written.First();
        Assert.AreEqual("test", written.Bucket);
        Assert.AreEqual("Inter", written.Org_id);

        var expected = new DemoModel()
                {String = "H", Number = 1, }.ToDataModel();
        var test = expected.ToPointModel();

        Assert.IsTrue(DatapointComparer.AreEqual(expected,written.Model));
    }
}
