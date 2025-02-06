using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SpectreConsole;

// ReSharper disable once CheckNamespace
namespace SerilogConsole;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "TODO";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        Log.Logger = new LoggerConfiguration()
            .WriteTo.SpectreConsole("{Timestamp:HH:mm:ss} [{Level:u4}] {Message:lj}{NewLine}{Exception}", minLevel: LogEventLevel.Verbose)
            .MinimumLevel.Verbose()
            .CreateLogger();
    }
}