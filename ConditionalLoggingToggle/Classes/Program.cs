using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ConditionalLoggingToggle;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Toggle log settings";
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
        Render(new Rule($"[white on blue]Press ENTER to exit[/]")
            .RuleStyle(Style.Parse("cyan"))
            .Centered());
        Console.ReadLine();
    }
}
