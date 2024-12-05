using Serilog.Templates;

namespace Serilog.ExpressionsAndITextFormatter;

internal partial class Program
{
    static void Main(string[] args)
    {
    
        Log.Information("{R1}", DateTime.Now);

        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Console.ReadLine();
    }
}