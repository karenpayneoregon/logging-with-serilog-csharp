using ConditionalLogging.Classes;
using Serilog;

namespace ConditionalLogging;

internal partial class Program
{
    static void Main(string[] args)
    {
        SetupLogging.Development();
        Log.Information("Hello");
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Console.ReadLine();
    }
}