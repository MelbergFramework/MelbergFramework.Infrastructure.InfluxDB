using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

namespace MelbergFramework.Infrastructure.InfluxDB;


public static class PointDataMapper
{
    public static  PointData ToPointModel(this InfluxDBDataModel model)
    {
        if (!model.Tags.Any())
        {
            throw new InvalidInfluxDBDataModelException("Tags were not given.");
        }

        if (!model.Fields.Any())
        {
            throw new InvalidInfluxDBDataModelException("Fields were not given.");
        }

        if (string.IsNullOrEmpty(model.Measurement))
        {
            throw new InvalidInfluxDBDataModelException("Measurement not given.");
        }

        var point = PointData.Measurement(model.Measurement);

        foreach (var item in model.Tags)
        {
            point = point.Tag(item.Key, item.Value);
        }

        foreach (var item in model.Fields)
        {
            point = point.Field(item.Key, item.Value);
        }

        point = point.Timestamp(model.Timestamp, WritePrecision.Ms);

        return point;
    }
}
