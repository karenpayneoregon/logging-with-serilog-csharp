using System.Runtime.CompilerServices;
using Serilog.ExpressionsAndITextFormatter.Classes;

// ReSharper disable once CheckNamespace
namespace Serilog.ExpressionsAndITextFormatter;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        SetupLogging.Development1();
    }
}
