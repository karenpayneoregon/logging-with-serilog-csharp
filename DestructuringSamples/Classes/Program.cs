using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DestructuringSamples.Classes;
using DestructuringSamples.Models;
using Serilog;

// ReSharper disable once CheckNamespace
namespace DestructuringSamples;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        Log.Logger = new LoggerConfiguration()
            .Destructure.With(new CustomerDestructuringPolicy())
            .WriteTo.Console()
            .CreateLogger();
    }
}
