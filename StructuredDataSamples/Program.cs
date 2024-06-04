using System.Text.Json;
using StructuredDataSamples.Classes;
using StructuredDataSamples.Models;

namespace StructuredDataSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        var fileName = $"LogFiles\\log{DateTime.Now:yyyyMMdd}.txt";
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        
        List<Customer> people = BogusOperations.PeopleList();
        AppLogger.Instance.Logger.Information("Person {@Person}", people);

        try
        {
            File.ReadAllLines("Customers.json");
        }
        catch (Exception e)
        {
            AppLogger.Instance.Logger.Error(e, "Missing Customers file.");
        }

        AppLogger.Instance.Logger.Dispose();

        var lines = File.ReadAllLines(fileName);

        var results = lines
            .Select(x => JsonSerializer.Deserialize<LogContainer>(x))
            .ToList();

        foreach (var result in results)
        {
            if (result.Properties is not null)
            {
                Console.WriteLine($"{result.Timestamp}");
                result.Properties.Person.ToList().ForEach(p =>
                {
                    Console.WriteLine($"   Id: {p.Id}, FirstName: {p.FirstName}, LastName: {p.LastName}, BirthDate: {p.BirthDate} Gender: {p.Gender}");
                });
            }
            else
            {
                AnsiConsole.MarkupLine($"   [red]Level: {result.Level}[/] [yellow]{result.MessageTemplate}[/]");
            }

        }

        Console.ReadLine();
    }
}