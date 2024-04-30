namespace MelbergFramework.Infrastructure.InfluxDB;

public class InvalidInfluxDBDataModelException : Exception
{
    public InvalidInfluxDBDataModelException(string message) : base(message) { }

    public InvalidInfluxDBDataModelException(string message, Exception ex) : base(message, ex) { }
}
