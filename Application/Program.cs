using Application.Infrastructure;
using MelbergFramework.Application;

namespace Application;
internal class Program
{
    private static async Task Main(string[] args)
    {
        var app = MelbergHost
            .CreateHost<AppRegistrator>()
            .Build(); 
        var repo  = app.Services.GetService<IDemoInfluxDBRepo>();
        await repo!.DoThings();
//        app.Run();
    }
}
