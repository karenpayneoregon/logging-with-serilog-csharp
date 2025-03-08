# About

An example of using Serilog is in Program.cs filters out system logging.

The idea is to allow focus to be on a developer's own logging and not be distracted by system logging while for instance debugging.

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)  // Suppress ASP.NET Core logs
    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)  // Suppress System logs
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

// Add Serilog to the logging pipeline
builder.Host.UseSerilog();
```