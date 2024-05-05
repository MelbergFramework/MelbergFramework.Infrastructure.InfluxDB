# MelbergFramework.Infrastructure.InfluxDB

InfluxDB implementation for MelbergFramework.

# Anatomy of Appsettings.json

Each Repository will use a class which inherits DefaultContext to perform rights.  See the demo for a clear example.

Use the [documentation](https://github.com/influxdata/influxdb-client-csharp?tab=readme-ov-file#writes-and-queries-in-influxdb-2x) to configure that connection string.

# Notes

## General Execution
This project requires dotnet 8 sdk to run (install link [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)).
## How to run a Redis Server
Docker installation guide for InfluxDB [here](https://hub.docker.com/_/influxdb).
