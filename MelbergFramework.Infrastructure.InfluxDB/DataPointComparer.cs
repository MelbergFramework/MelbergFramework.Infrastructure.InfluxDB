using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

namespace MelbergFramework.Infrastructure.InfluxDB;

public static class DatapointComparer
{
    public static bool AreEqual(
            InfluxDBDataModel model, PointData data
)
    {
        model.Timestamp = DateTime.MinValue;
        data = data.Timestamp(DateTime.MinValue, WritePrecision.Ms);
        return model.ToPointModel() == data;
    }
}
