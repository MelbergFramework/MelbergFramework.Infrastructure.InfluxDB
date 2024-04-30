using MelbergFramework.Infrastructure.InfluxDB;

namespace Application.Infrastructure;

public interface IDemoInfluxDBRepo { 
    Task DoThings();
}

public class DemoInfluxDBRepo : BaseInfluxDBRepository<InfluxDBContext>, IDemoInfluxDBRepo
{
    public DemoInfluxDBRepo(InfluxDBContext context) : base(context) { }

    public async Task DoThings()
    {
        var good = await Context.PingAsync();

        await Context
            .WritePointAsync(
                new DemoModel()
                {String = "H",
                Number = 1}.ToDataModel()
                ,"test","Inter");

    }
}
