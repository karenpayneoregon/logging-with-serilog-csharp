using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using CombinedConfigDemo.Data;
using CombinedConfigDemo.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Spectre.Console;

namespace SqlServerSink.Classes;

[SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
internal class LogOperations
{
    /// <summary>
    /// Create various types of log entries
    /// </summary>
    public static void CreateSomeLogs()
    {
        static void TruncateLogTable()
        {
            using var context = new LogContext();

            var count = context.LogEvents.Count();

            if (count > 0)
            {
                context.Database.ExecuteSqlRaw($"TRUNCATE TABLE [{nameof(LogEvents)}]");
            }
        }
        
        TruncateLogTable();

        Log.Information("Hello {Name} from thread {ThreadId}", Environment.GetEnvironmentVariable("USERNAME"),
            Thread.CurrentThread.ManagedThreadId);

        Log.Warning("Bad lat long {@Position}", new { Lat = 25, Long = 134 });

        Log.Error(new JsonException("Something is wrong"), "Json issue");

        var fileName = "Customers.txt";

        try
        {
            var lines = File.ReadAllLines(fileName);
        }
        catch (Exception e)
        {
            Log.Error(e, $"Failed to read {fileName}");
        }

        Log.Information("Bye");

        Log.CloseAndFlush();

        AnsiConsole.MarkupLine("[yellow]Finish creating entries, press ENTER for menu[/]");

        Console.ReadLine();
    }



    public static void ViewInformationEntries()
    {
        using var context = new LogContext();
        var list = context.LogEvents.Where(x => x.Level == "Information").ToList();

        var table = CreateTable("Information");

        foreach (var entry in list)
        {
            var displayNameWithCurrentOffset = TimeZoneInfo.Local.GetDisplayNameWithCurrentOffset(entry.LogEvent.Timestamp.Value);
            table.AddRow(entry.Id.ToString(), $"{entry.LogEvent.Timestamp.Value:MM:dd:yyyy hh:mm:ss tt} {displayNameWithCurrentOffset}", entry.Message);
        }

        AnsiConsole.Write(table);

        AnsiConsole.MarkupLine("[yellow]Press ENTER for menu[/]");
        Console.ReadLine();

    }

    public static void ViewEntries(string logType)
    {
        using var context = new LogContext();
        var list = context.LogEvents.Where(x => x.Level == logType).ToList();

        var table = CreateTable("Error");

        foreach (var entry in list)
        {
            var displayNameWithCurrentOffset = TimeZoneInfo.Local.GetDisplayNameWithCurrentOffset(entry.LogEvent.Timestamp.Value);
            table.AddRow(entry.Id.ToString(), $"{entry.LogEvent.Timestamp.Value:MM:dd:yyyy hh:mm:ss tt} {displayNameWithCurrentOffset}", entry.Message);
        }

        AnsiConsole.Write(table);

        AnsiConsole.MarkupLine("[yellow]Press ENTER for menu[/]");
        Console.ReadLine();
        
    }
    public static void ViewErrorEntries()
    {
        using var context = new LogContext();
        var list = context.LogEvents.Where(x => x.Level == "Error").ToList();

        var table = CreateTable("Error");

        foreach (var entry in list)
        {
            var displayNameWithCurrentOffset = TimeZoneInfo.Local.GetDisplayNameWithCurrentOffset(entry.LogEvent.Timestamp.Value);
            table.AddRow(entry.Id.ToString(), $"{entry.LogEvent.Timestamp.Value:MM:dd:yyyy hh:mm:ss tt} {displayNameWithCurrentOffset}", entry.Message);
        }

        AnsiConsole.Write(table);

        AnsiConsole.MarkupLine("[yellow]Press ENTER for menu[/]");
        Console.ReadLine();

    }

    public static void ViewWarningEntries()
    {
        using var context = new LogContext();
        var list = context.LogEvents.Where(x => x.Level == "Warning").ToList();

        var table = CreateTable("Warning");

        foreach (var entry in list)
        {
            var displayNameWithCurrentOffset = TimeZoneInfo.Local.GetDisplayNameWithCurrentOffset(entry.LogEvent.Timestamp.Value);
            table.AddRow(entry.Id.ToString(), $"{entry.LogEvent.Timestamp.Value:MM:dd:yyyy hh:mm:ss tt} {displayNameWithCurrentOffset}", entry.Message);
        }

        AnsiConsole.Write(table);

        AnsiConsole.MarkupLine("[yellow]Press ENTER for menu[/]");
        Console.ReadLine();

    }

    private static Table CreateTable(string title)
    {

        var table = new Table()
            .RoundedBorder()
            .AddColumn("[b]Id[/]")
            .AddColumn("[b]Timestamp[/]")
            .AddColumn("[b]Message[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title($"[yellow]{title} entries[/]");

        return table;
    }
}
