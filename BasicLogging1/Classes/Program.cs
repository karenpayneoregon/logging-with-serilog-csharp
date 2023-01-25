using Spectre.Console;

namespace BasicLogging1;
internal partial class Program
{
    private static void Render(Rule rule)
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
