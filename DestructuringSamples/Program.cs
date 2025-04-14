using DestructuringSamples.Classes;
using Serilog;

namespace DestructuringSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[hotpink]Destructure Customers[/]");

        foreach (var customer in MockedData.Customers())
        {
            Log.Information("Customers {@C}", customer);
        }

        AnsiConsole.MarkupLine("[v]Done[/]");
        Console.ReadLine();
    }
}