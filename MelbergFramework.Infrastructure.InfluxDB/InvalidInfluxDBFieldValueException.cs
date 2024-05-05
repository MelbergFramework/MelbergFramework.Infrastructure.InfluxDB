namespace MelbergFramework.Infrastructure.InfluxDB;

public class InvalidInfluxDBFieldValueException : Exception
{
    public InvalidInfluxDBFieldValueException(string message) : base(message) { }
    public InvalidInfluxDBFieldValueException(string message, Exception ex) : base(message, ex) { }
}
