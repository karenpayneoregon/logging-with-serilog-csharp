using DestructuringSamples.Classes;
using Serilog;

namespace DestructuringSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[hotpink]FirstName, LastName and office phone[/]");


        Log.Logger = new LoggerConfiguration()
            .Destructure.With(new FirstLastNamesWithPhonePolicy())
            .WriteTo.Console()
            .CreateLogger();

        foreach (var customer in MockedData.Customers())
        {
            Log.Information("Customers {@C}", customer);
        }

        Console.WriteLine();

        AnsiConsole.MarkupLine("[hotpink]Id,FirstName, LastName[/]");
        Log.Logger = new LoggerConfiguration()
            .Destructure.With(new IdentifierFirstLastNamesWithPolicy())
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