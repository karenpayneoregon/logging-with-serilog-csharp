# About

Simple example for Serilog writing too a secondary window using NuGet package [Serilog.Sinks.WinForms.Core](https://www.nuget.org/packages/Serilog.Sinks.WinForms.Core)


## Remarks

- Prior logs are lost once the log form is closed
- Does not colorize log entries
- Supports other controls, see their docs

## Setup

**Program.cs**

```csharp
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ConfigureSerilog();
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
    private static void ConfigureSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteToGridView()
            .WriteToJsonTextBox()
            .WriteToSimpleAndRichTextBox()
            .CreateLogger();
    }
}
```