using Serilog;
using SerilogConsole.Classes;
using static SerilogConsole.Classes.SpectreConsoleHelpers;

namespace SerilogConsole;

internal partial class Program
{
    static void Main(string[] args)
    {
        DataOperations.Connect();
        Log.Information("Today is {0}", DateTime.Now.ToShortDateString());
        AnsiConsole.MarkupLine("[cyan]Welcome[/]");

        ExitPrompt();
    }
}