using System.ComponentModel.DataAnnotations;

namespace MelbergFramework.Infrastructure.InfluxDB;
public interface IInfluxDBOptions 
{
    string Uri {get;}
}

public class InfluxDBOptions<TContext> : IInfluxDBOptions
    where TContext : DefaultContext
{
    public static string Section => $"{typeof(TContext).Name}";// "InfluxDB";

    [Required]
    [MinLength(1)]
    public string Uri {get; set;} = string.Empty;
}
