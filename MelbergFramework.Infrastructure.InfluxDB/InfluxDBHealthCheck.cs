using MelbergFramework.Core.HealthCheck;
using Microsoft.Extensions.DependencyInjection;

namespace MelbergFramework.Infrastructure.InfluxDB;

public class InfluxDBHealthCheck<TContext> : HealthCheck
    where TContext : DefaultContext    
{
    private readonly TContext _client;

    public InfluxDBHealthCheck(IServiceProvider serviceProvider)
    {
        _client = serviceProvider.GetRequiredService<TContext>();
    }

    public override string Name => typeof(TContext).Name+"_influxdb";

    public override Task<bool> IsOk(CancellationToken token) =>
        _client.PingAsync();
}
