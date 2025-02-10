using Microsoft.Extensions.Configuration;
using Serilog;
using SerilogFiltering.Interfaces;
using SerilogFiltering.Classes;
using SerilogTimings;
using SerilogFiltering.Models;

namespace SerilogFiltering;

internal partial class Program
{
    static void Main(string[] args)
    {
        
        // writes to log.txt
        Log.Information("Start of code sample");

        List<IPerson> people = MockedData.List();

        if (UseSerilogTiming())
        {
            LogPeopleDetailsWithTiming(people);
        }
        else
        {
            LogPeopleDetail(people);
        }
        

        Log.Information("End of code sample");

        Log.CloseAndFlush();

        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }


    /// <summary>
    /// Logs the details of a list of people with timing information using Serilog and SerilogTimings.
    /// </summary>
    /// <param name="people">
    /// A list of <see cref="IPerson"/> objects whose details will be logged.
    /// </param>
    /// <remarks>
    /// This method iterates over the provided list of people, logs their details, and measures the time taken 
    /// for the operation using SerilogTimings. Each person's details are logged in a structured format.
    /// </remarks>
    private static void LogPeopleDetailsWithTiming(List<IPerson> people)
    {
        using var op = Operation.Begin("Iteration over people list");
        foreach (var (index, person) in people.Index())
        {
            Console.WriteLine($"{index,-5}{person}");
            // writes to person.txt
            person.LogDetails();
        }

        op.Complete();

    }

    /// <summary>
    /// Logs the details of a list of people to the console and invokes their individual logging functionality.
    /// </summary>
    /// <param name="people">
    /// A list of objects implementing the <see cref="IPerson"/> interface, representing the people whose details are to be logged.
    /// </param>
    /// <remarks>
    /// This method iterates through the provided list of people, logs their index and details to the console, 
    /// and calls the <see cref="IPerson.LogDetails"/> method for each person to log their structured details.
    /// </remarks>
    private static void LogPeopleDetail(List<IPerson> people)
    {
        foreach (var (index, person) in people.Index())
        {
            Console.WriteLine($"{index,-5}{person}");
            // writes to person.txt
            person.LogDetails();
        }

    }
}

