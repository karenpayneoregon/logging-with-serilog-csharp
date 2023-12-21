using System.Runtime.CompilerServices;
using static DumpObjectsApp.Classes.SeriLogSetupLogging;

// ReSharper disable once CheckNamespace
namespace DumpObjectsApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Development();
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Top);
    }
}
