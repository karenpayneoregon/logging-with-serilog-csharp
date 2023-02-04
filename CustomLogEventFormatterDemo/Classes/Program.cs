using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;
using Spectre.Console;



namespace CustomLogEventFormatterDemo;

public partial class Program
{

    [ModuleInitializer]
    public static void Init()
    {

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
        AnsiConsole.Write(
            new FigletText("Inspect table")
                .Color(Color.CadetBlue));
        Console.WriteLine();
        Render(new Rule($"[white on blue]Press a key to exit the demo[/]")
            .RuleStyle(Style.Parse("cyan"))
            .Centered());
        Console.ReadLine();
    }
}
