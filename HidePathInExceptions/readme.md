# About

SeriLog is configured in `Serilog.json` as shown below, no different than working with `appsettings.json` in any C# project.

```json
{
  "Serilog": {
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "File",
        "Args": {
          "path": ".\\LogFiles\\log.txt",
          "rollingInterval": "Day"
        }
      }
    ]
  }
}
```

To disable logging replace `Serilog.json` contents with the following. The key is ` "Default": "6"` which was difficult to find as it does not appear in official documentation which is not surprising as I feel into a similar hole with working out writing to a database in the project `CombinedConfigDemo`.

```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "6" /* disable logging */
    },
    "WriteTo": [
      {
        "Name": "File",
        "Args": {
          "path": ".\\LogFiles\\log.txt",
          "rollingInterval": "Day"
        }
      }
    ]
  }
}
```
# Code configuration

This is done in a singleton class which means to access the logger we write `SeriControl.Instance.Logger.Write(LogEventLevel.Error, localException, "TODO");`

```csharp
public sealed class SeriControl
{
    private static readonly Lazy<SeriControl> Lazy = new(() => new SeriControl());
    public static SeriControl Instance => Lazy.Value;
    private static Logger _logger;
    public Logger Logger => _logger;
    private SeriControl()
    {
        // setup to read setting from Serilog.json
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("Serilog.json", true, true)
            .Build();

        _logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

    }
}
```

## What it does

- Writes to a log under the application folder in a folder named LogFiles, the logfile written is one for each day which is good as a log file can grow to a very large size which can also be constroled by SeriLog yet it is better to have different files per day.
- rollingInterval options
    - **Infinite** The log file will never roll; no time period information will be appended to the log file name.
    - **Year** Roll every year. Filenames will have a four-digit year appended in the pattern <code>yyyy</code>.
    - **Month** Roll every day. Filenames will have <code>yyyyMMdd</code> appended.
    - **Hour** Roll every hour. Filenames will have <code>yyyyMMddHH</code> appended.
    - **Minute** Roll every minute. Filenames will have <code>yyyyMMddHHmm</code> appended.

# Limiting file size

You can add another option to the json file to limit file size `fileSizeLimitBytes`, so for limiting to 1GB we would use

```
fileSizeLimitBytes:100000
```

# Retention

By default only the most recent 31 files are retained. To override, in this case for 100 days

```
retainedFileCountLimit: 100
```

In an enterprise environment it makes sense to have a longer retention but consider creating a job that you control cleanup. The job would take x days of logs and move them to an archive folder.

