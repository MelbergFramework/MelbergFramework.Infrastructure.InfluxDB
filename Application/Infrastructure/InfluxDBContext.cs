using MelbergFramework.Infrastructure.InfluxDB;
using Microsoft.Extensions.Options;

namespace Application.Infrastructure;

public class InfluxDBContext : DefaultContext
{
    public InfluxDBContext(
            IOptions<InfluxDBOptions<InfluxDBContext>> options) 
        : base(options.Value)
    {
    }
}
