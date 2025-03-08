# About

An example of using Serilog is in Program.cs filters out system logging.


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