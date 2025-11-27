
using DestructuringSamples1.Classes;
using Serilog;

namespace DestructuringSamples1;

internal partial class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();


        foreach (var customer in MockedData.Customers())
        {
            Log.Information("Customers {@C}", customer);
        }

        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}