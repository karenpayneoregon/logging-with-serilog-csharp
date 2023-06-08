# About

Simple example for Serilog writing too

- Visual Studio output window
- To a log file

For writing to the output window add the package [Serilog.Sinks.Debug](https://www.nuget.org/packages/Serilog.Sinks.Debug/2.0.0?_src=template)

## Setup

:small_blue_diamond: Program.cs

```csharp
internal static class Program
{

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        SetupLogging.Development();
        Application.Run(new Form1());
    }
}
```

:small_blue_diamond: Classes\SetupLogging.cs

```csharp
public class SetupLogging
{

    public static void Development()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Debug()
            .WriteTo.File(Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, 
                    "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

    }

}
```

## Output window colors

SeriLog does not colorize but a cheat to get exceptions colored install [VSColorOutput64](https://marketplace.visualstudio.com/items?itemName=MikeWard-AnnArbor.VSColorOutput64) extension.