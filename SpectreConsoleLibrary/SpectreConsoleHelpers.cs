using System.Runtime.CompilerServices;
using Spectre.Console;
#pragma warning disable CS8604 // Possible null reference argument.

namespace SpectreConsoleLibrary;

public static class SpectreConsoleHelpers
{
    /// <summary>
    /// Prompts the user to exit the application.
    /// </summary>
    public static void ExitPrompt()
    {
        Console.WriteLine();
        AnsiConsole.MarkupLine("[bold cyan]Press any key to exit...[/]");

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    /// <summary>
    /// Prints a formatted message to the console in pink color, including the project name, file name, and method name.
    /// </summary>
    /// <param name="filePath">
    /// The file path of the caller. This parameter is automatically populated by the compiler.
    /// </param>
    /// <param name="methodName">
    /// The name of the calling method. This parameter is automatically populated by the compiler.
    /// </param>
    public static void PrintPink([CallerFilePath] string? filePath = null, [CallerMemberName] string? methodName = null)
    {

        // Get file and project name
        var fileName = Path.GetFileNameWithoutExtension(filePath);
        var projectName = Utilities.GetProjectName(filePath);

        AnsiConsole.MarkupLine($"[hotpink2]{projectName}[/][yellow bold].[/][hotpink2]" +
                               $"{fileName}[/][yellow bold].[/][hotpink2]{methodName}[/]");
        
        Console.WriteLine();
    }

    public static void LineSeparator()
    {
        AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("grey")).Centered());
    }

    /// <summary>
    /// Spectre.Console  Add [ to [ and ] to ] so Children[0].Name changes to Children[[0]].Name
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static string ConsoleEscape(this string sender)
        => Markup.Escape(sender);

    /// <summary>
    /// Spectre.Console Removes markup from the specified string.
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static string ConsoleRemove(this string sender)
        => Markup.Remove(sender);


}