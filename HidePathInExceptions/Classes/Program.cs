using System;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace HidePathInExceptions;

partial class Program
{
    //private static Logger Logger;

    [ModuleInitializer]
    public static void Init()
    {

        Console.Title = "Exception without path code sample with Serilog/Spectre.Console";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}