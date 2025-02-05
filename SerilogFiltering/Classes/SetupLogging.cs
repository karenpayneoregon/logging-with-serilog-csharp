﻿using Serilog;
using Serilog.Filters;
using SerilogFiltering.Models;
using SerilogFiltering.Interfaces;
using static System.DateTime;

namespace SerilogFiltering.Classes;
internal class SetupLogging
{
    /// <summary>
    /// Configures the logging setup for the development environment.
    /// </summary>
    /// <remarks>
    /// This method initializes the Serilog logger with specific configurations:
    /// <list type="bullet">
    /// <item>
    /// <description>Logs general application events to a file named <c>Log.txt</c>, excluding logs with the <c>Category</c> property set to <c>Person</c>.</description>
    /// </item>
    /// <item>
    /// <description>Logs events specific to the <c>Person</c> category to a separate file named <c>Person.txt</c>.</description>
    /// </item>
    /// </list>
    /// The log files are stored in a directory named <c>LogFiles</c>, located in the application's base directory, with a subdirectory named after the current date.
    /// </remarks>
    public static void Development()
    {
        var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now:yyyy-MM-dd}");

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Information()

            // General logging (Excludes Person logs)
            .WriteTo.Logger(lc => lc
                .Filter.ByExcluding(Matching.WithProperty("Category", nameof(IPerson)))
                .WriteTo.File(Path.Combine(logDirectory, "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level}] {Message}{NewLine}{Exception}"))

            // Person-specific logging (Only includes Person logs)
            .WriteTo.Logger(lc => lc
                .Filter.ByIncludingOnly(Matching.WithProperty("Category", nameof(IPerson)))
                .WriteTo.File(Path.Combine(logDirectory, $"{nameof(Person)}.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level}] {Message}{NewLine}{Exception}"))

            .CreateLogger();
    }
}

