using InfluxDB.Client;
using InfluxDB.Client.Writes;

namespace MelbergFramework.Infrastructure.InfluxDB;

public interface IStandardClient 
{
    Task WritePointDataAsync(PointData data, string bucket, string org);
    Task<bool> PingAsync();
}
public class StandardClient : InfluxDBClient, IStandardClient
{
    private readonly WriteApiAsync _writer;
    private readonly InfluxDBClient _client;

    public StandardClient(string uri) : base(uri)
    {
        _client = new InfluxDBClient(uri);
        _writer = _client.GetWriteApiAsync();
    }

    public Task WritePointDataAsync(
            PointData data,
            string bucket,
            string org) => _writer.WritePointAsync(data,bucket,org);

    public Task<bool> PingAsync() => _client.PingAsync();
}
