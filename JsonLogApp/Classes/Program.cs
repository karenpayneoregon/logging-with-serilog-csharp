using System.Runtime.CompilerServices;
using Serilog;
using SeriLogLibrary;

// ReSharper disable once CheckNamespace
namespace JsonLogApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        
        
    }

    private static void SeriLogForJson()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(theme: SeriLogCustomThemes.JsonTheme())
            .CreateLogger();

    }
    private static void SeriLogSimple()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(theme: SeriLogCustomThemes.Theme2())
            .CreateLogger();

    }
}
