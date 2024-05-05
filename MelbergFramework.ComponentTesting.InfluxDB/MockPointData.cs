using InfluxDB.Client.Writes;

namespace MelbergFramework.ComponentTesting.InfluxDB;

public class MockPointData
{
    public MockPointData(
            PointData model,
            string bucket,
            string org_id
            )
    {
        Model = model;
        Bucket = bucket;
        Org_id = org_id;
    }
    public PointData Model {get; set;}
    public string Bucket {get; set;}
    public string Org_id {get; set;}
}
