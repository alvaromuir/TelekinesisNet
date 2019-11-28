# TelekinesisNet

Telekinesis is a simple AWS Lambda streaming app focused on [snowplow](https://github.com/snowplow/snowplow) formatted events.

Built in C# .NET Core 3.0

## Deployment to Azure App Service
Telekinesis can be deployed as a 'WebJob' to Azure. To do so, leverage an App.config with the appropriate settings. An example config has been provided.

## Running
Telekinsis is intended to run as a console app, and therefore has command line parametes. It can be run from the `$ dotnet run -- [- params]` command or from  
the build directory.

run `$ <build dir> ./TelekinesisNet`

```bash
  -n, --name           Required. The name of Kinesis stream.

  -r, --region         Required. The AWS Region.

  -e, --enriched       The results are enriched.

  --help               Display this help screen.

  --version            Display version information.

  max (pos. 0)         The maximum records to return; default 0 (infinite).

  interval (pos. 1)    The response intervals; default 1 second.

  limit (pos. 25)      The records per shard limit; default 25, minimum is 2
```

As aforemntioned, a App.config file will supersede any command line paramters, and a INFO logging message will indicate this.

[Alvaro Muir](mailto:alvaro@coca-cola.com)  
KO MDS Global Analytics
