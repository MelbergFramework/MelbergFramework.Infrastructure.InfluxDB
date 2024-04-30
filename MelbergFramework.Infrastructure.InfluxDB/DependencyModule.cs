using MelbergFramework.Core.HealthCheck;
using Microsoft.Extensions.DependencyInjection;

namespace MelbergFramework.Infrastructure.InfluxDB;

public static class InfluxDBDependencyModule
{
    public static void LoadInfluxDBRepository<TFrom,TTo,TContext>(IServiceCollection services)
        where TTo : BaseInfluxDBRepository<TContext>, TFrom
        where TFrom : class
        where TContext : DefaultContext
    {
        services
            .AddOptions<InfluxDBOptions<TContext>>()
            .BindConfiguration(InfluxDBOptions<TContext>.Section)
            .ValidateOnStart();

        services
            .AddSingleton<TContext,TContext>()
            .AddTransient<TFrom, TTo>();

        services.AddSingleton<IHealthCheck,InfluxDBHealthCheck<TContext>>();
    }
}
