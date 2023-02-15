# About

Basic EF Core logging done in `appsettings.Development.json`, no SeriLog. See `WriteSeparateFromEfCore` project for more indepth logging with SeriLog.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NorthWind2022;Integrated Security=True;Encrypt=False"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information",
      "Microsoft.EntityFrameworkCore.Database.Command": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

- [Message categories](https://learn.microsoft.com/en-us/ef/core/logging-events-diagnostics/simple-logging#message-categories)
- [Log levels](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel?view=dotnet-plat-ext-3.1)


