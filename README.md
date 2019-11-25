# TelekinesisNet

Telekinesis is a simple AWS Lambda streaming app focused on [snowplow](https://github.com/snowplow/snowplow) formatted events.

Built in C# .NET Core 3.0

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

[Alvaro Muir](mailto:alvaro@coca-cola.com)  
KO MDS Global Analytics
