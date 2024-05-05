using Application.Infrastructure;
using MelbergFramework.Application;
using MelbergFramework.Infrastructure.InfluxDB;

namespace Application;

public class AppRegistrator : Registrator
{
    public override void RegisterServices(IServiceCollection services)
    {
        InfluxDBDependencyModule
            .LoadInfluxDBRepository<
            IDemoInfluxDBRepo,DemoInfluxDBRepo, InfluxDBContext>(services);
    }
}
