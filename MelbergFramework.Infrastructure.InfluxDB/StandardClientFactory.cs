using InfluxDB.Client;

namespace MelbergFramework.Infrastructure.InfluxDB;

public interface IStandardClientFactory 
{
    IStandardClient GetClient(string uri);
}

public class StandardClientFactory : IStandardClientFactory
{
    private readonly Dictionary<string,StandardClient> _clients =
        new Dictionary<string, StandardClient>();

    public StandardClientFactory() { }

    public IStandardClient GetClient(string uri)
    {
        if(!_clients.ContainsKey(uri))
        {
            _clients.Add(uri, new StandardClient(uri));
        }
        return _clients[uri];
    }
}
