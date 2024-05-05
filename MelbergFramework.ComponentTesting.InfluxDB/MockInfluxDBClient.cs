using InfluxDB.Client.Writes;
using MelbergFramework.Infrastructure.InfluxDB;

namespace MelbergFramework.ComponentTesting.InfluxDB;

public class MockInfluxDBClient : IStandardClient
{
    public bool IsHealthy {get; set;}
    public List<MockPointData> Written = new List<MockPointData>();
    public MockInfluxDBClient() { }

    public Task<bool> PingAsync() => Task.FromResult(IsHealthy);

    public Task WritePointDataAsync(PointData data, string bucket, string org)
    {
        Written.Add(new MockPointData(data, bucket, org));

        return Task.CompletedTask;
    }
}
