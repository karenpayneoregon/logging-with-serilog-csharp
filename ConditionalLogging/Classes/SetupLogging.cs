using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using static System.DateTime;
namespace ConditionalLogging.Classes;
public class SetupLogging
{
    /// <summary>
    /// Configures and initializes logging for the development environment.
    /// </summary>
    /// <remarks>
    /// This method sets up logging using Serilog. It reads configuration settings from the 
    /// "appsettings.json" file to determine whether SQL command logging is enabled. Depending on 
    /// the configuration, it creates a logger with appropriate settings, including console and 
    /// file sinks, log levels, and output templates.
    /// </remarks>
    /// <exception cref="System.IO.IOException">
    /// Thrown if there is an issue accessing the log file path.
    /// </exception>
    /// <example>
    /// To use this method, call it at the start of your application:
    /// <code>
    /// SetupLogging.Development();
    /// Log.Information("Application started.");
    /// </code>
    /// </example>
    public static void Development()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();


        if (Convert.ToBoolean(configuration.GetSection("Debug")["LogSqlCommand"]))
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
        else
        {
            LoggingLevelSwitch ls = new() { MinimumLevel = ((LogEventLevel)1 + (int)LogEventLevel.Fatal) };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.ControlledBy(ls)
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }

    }

}