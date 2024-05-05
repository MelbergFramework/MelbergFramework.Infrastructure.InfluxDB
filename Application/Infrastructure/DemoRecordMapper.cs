using MelbergFramework.Infrastructure.InfluxDB;

namespace Application.Infrastructure;

public static class DemoRecordMapper
{
    public static InfluxDBDataModel ToDataModel(this DemoModel model)
    {
       var result = new InfluxDBDataModel("test"); 

       result.Tags["Str"] = model.String;
       result.Fields["Int"] = model.Number;

       result.Timestamp = DateTime.UtcNow;
       return result;
    }
}
