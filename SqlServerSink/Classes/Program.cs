using Spectre.Console;
using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;
using SqlServerSink.Classes;
using Rule = Spectre.Console.Rule;

// ReSharper disable once CheckNamespace
namespace CombinedConfigDemo;
internal partial class Program
{

    [ModuleInitializer]
    public static void Init()
    {
        SetupLogging.Initialize();
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    private static void Render(Spectre.Console.Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    private static void ExitPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[white on blue]Press a key to exit the demo[/]")
            .RuleStyle(Style.Parse("cyan"))
            .Centered());
    }
}
