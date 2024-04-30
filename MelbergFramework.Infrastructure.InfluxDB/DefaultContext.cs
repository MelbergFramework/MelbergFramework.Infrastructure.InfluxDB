using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

namespace MelbergFramework.Infrastructure.InfluxDB;

public interface IInfluxDBContext
{
    public Task WritePointAsync(
            InfluxDBDataModel model,
            string bucket,
            string org_id);

public class DefaultContext
{
    private readonly WriteApiAsync WriteApi;

    private readonly InfluxDBClient _client;
    public DefaultContext(IInfluxDBOptions options)
    {
        _client = new InfluxDBClient(options.Uri);
        WriteApi = _client.GetWriteApiAsync();
    }

    public Task WritePointAsync(
            InfluxDBDataModel model,
            string bucket,
            string org_id) =>
        WriteApi.WritePointAsync(ToPointModel(model), bucket, org_id);

    public PointData ToPointModel(InfluxDBDataModel model)
    {
        if (!model.Tags.Any())
        {
            throw new InvalidInfluxDBDataModelException("Tags were not given.");
        }

        if (!model.Fields.Any())
        {
            throw new InvalidInfluxDBDataModelException("Fields were not given.");
        }

        if (string.IsNullOrEmpty(model.Measurement))
        {
            throw new InvalidInfluxDBDataModelException("Measurement not given.");
        }

        var point = PointData.Measurement(model.Measurement);

        foreach (var item in model.Tags)
        {
            point = point.Tag(item.Key, item.Value);
        }

        foreach (var item in model.Fields)
        {
            point = point.Field(item.Key, item.Value);
        }

        point = point.Timestamp(model.Timestamp, WritePrecision.Ms);

        return point;
    }

    private string KeyValueToString(string key, object value, bool isTag) => $"{key}={StringEscaper(value, isTag)}";

    private string StringEscaper(object value, bool isTag)
    {
        if (value is string)
        {
            return "{value}".Replace("{value}", ((!isTag) ? "\"" : "") + value.ToString() + ((!isTag) ? "\"" : ""));
        }
        return value?.ToString() ?? throw new Exception("Could not escape value");
    }

    public Task<bool> PingAsync() => _client.PingAsync();

}
