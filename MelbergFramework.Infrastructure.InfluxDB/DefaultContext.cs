using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

namespace MelbergFramework.Infrastructure.InfluxDB;

public class DefaultContext
{
    private readonly IStandardClient _client;
    public DefaultContext(IStandardClientFactory factory, IInfluxDBOptions options)
    {
        _client = factory.GetClient(options.Uri);
    }

    public Task WritePointAsync(
            InfluxDBDataModel model,
            string bucket,
            string org_id) =>
        _client.WritePointDataAsync(model.ToPointModel(), bucket, org_id);

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
