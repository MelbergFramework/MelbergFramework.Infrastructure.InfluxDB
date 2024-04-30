namespace MelbergFramework.Infrastructure.InfluxDB;

public class InfluxDBDataModel
{
    public IDictionary<string,string> Tags {get; set;}
    public IDictionary<string,object> Fields {get; set;}
    public string Measurement {get; set;}
    public DateTime Timestamp {get; set;}

    public InfluxDBDataModel(string measurement)
    {
        Tags = new Dictionary<string,string>();
        Fields = new Dictionary<string,object>();
        Measurement = measurement;
    }
}
