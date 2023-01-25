using ConsoleHelperLibrary.Classes;
using System.Runtime.CompilerServices;

namespace BasicLogging1.Classes;

internal class Startup
{
    [ModuleInitializer]
    public static void Init()
    {

        Console.Title = "Serilog log to console";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }   
}