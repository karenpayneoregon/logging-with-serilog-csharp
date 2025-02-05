using Serilog;
using SerilogFiltering.Interfaces;
using System.Xml.Linq;
using SerilogFiltering.Classes;
using SerilogFiltering.Models;

namespace SerilogFiltering;

internal partial class Program
{
    static void Main(string[] args)
    {
        Log.Information("Hello");
        List<IPerson> people = MockedData.List();

        people.FirstOrDefault().LogDetails();

        foreach (var person in people)
        {
            Console.WriteLine(person);
            person.LogDetails();
        }
        
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}