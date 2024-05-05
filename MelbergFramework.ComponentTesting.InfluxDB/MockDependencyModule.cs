using MelbergFramework.ComponentTesting.InfluxDB;
using MelbergFramework.Core.DependencyInjection;
using MelbergFramework.Infrastructure.InfluxDB;
using Microsoft.Extensions.DependencyInjection;

public static class MockInfluxDBDependencyModule
{
    public static void MockInfluxDBContext<TContext>(IServiceCollection services)
        where TContext : DefaultContext
    {
        services
            .OverrideWithSingleton<IStandardClientFactory, MockInfluxDBClientFactory>()
            .Configure<InfluxDBOptions<TContext>>( _ =>_.Uri = typeof(TContext).Name);
    }
}
