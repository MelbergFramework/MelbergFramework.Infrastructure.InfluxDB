using Application;
using Application.Infrastructure;
using LightBDD.MsTest3;
using MelbergFramework.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Features;

public class BaseTestFrame : FeatureFixture
{
    public BaseTestFrame()
    {
        App = MelbergHost.CreateHost<AppRegistrator>()
            .AddServices(_ => 
            {
               MockInfluxDBDependencyModule.MockInfluxDBContext<InfluxDBContext>(_);
            })
            .AddControllers()
            .Build();
    }
    public WebApplication App;

    public T GetClass<T>() => (T)App
        .Services
        .GetRequiredService(typeof(T));

}
