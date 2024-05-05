using MelbergFramework.Infrastructure.InfluxDB;

namespace MelbergFramework.ComponentTesting.InfluxDB;

public class MockInfluxDBClientFactory : IStandardClientFactory
{
    private readonly Dictionary<string,MockInfluxDBClient> _clients =
        new Dictionary<string, MockInfluxDBClient>();

    public IStandardClient GetClient(string uri)
    {
        if(!_clients.ContainsKey(uri))
        {
            _clients.Add(uri, new MockInfluxDBClient());
        }

        return _clients[uri];
    }
}
