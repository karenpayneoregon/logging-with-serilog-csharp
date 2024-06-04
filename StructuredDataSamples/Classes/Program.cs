using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace StructuredDataSamples;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("[cyan]Serilog singleton json file[/]");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
