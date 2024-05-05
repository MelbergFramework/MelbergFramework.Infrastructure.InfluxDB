using InfluxDB.Client;
using InfluxDB.Client.Writes;

namespace MelbergFramework.Infrastructure.InfluxDB;

//This file exists because I cannot Mock the writer, the bucket and orgId 
// parameters are optional.
public interface IInfluxWriter
{
    Task WritePoint(PointData data, string bucket, string orgId);
}

public class InfluxWriter : IInfluxWriter
{
    private readonly WriteApiAsync _writer;


    public InfluxWriter(WriteApiAsync writer) => _writer = writer;

    public Task WritePoint(PointData data, string bucket, string orgId) =>
        _writer.WritePointAsync(data, bucket, orgId);
}
