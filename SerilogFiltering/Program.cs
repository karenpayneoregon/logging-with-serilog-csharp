using Serilog;
using SerilogFiltering.Interfaces;
using SerilogFiltering.Classes;

namespace SerilogFiltering;

internal partial class Program
{
    static void Main(string[] args)
    {
        Log.Information("Hello");
        List<IPerson> people = MockedData.List();


        foreach (var (index, person) in people.Index())
        {
            Console.WriteLine($"{index,-5}{person}");
            person.LogDetails();
        }
        
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}