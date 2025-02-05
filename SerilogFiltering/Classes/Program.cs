using System.Runtime.CompilerServices;
using SerilogFiltering.Classes;

// ReSharper disable once CheckNamespace
namespace SerilogFiltering;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        SetupLogging.Development();
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
