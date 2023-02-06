using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using SeriLogLibrary;

namespace SerilogCustomLogColors.Classes;

/// <summary>
/// For setting up SeriLog to keep Program.Main clean and allows code to be easily copied to other projects.
/// </summary>
public class SetupLogging
{
    /// <summary>
    /// Development logging
    /// </summary>
    public static void Development()
    {

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(theme: SeriLogCustomThemes.Theme1())
            .CreateLogger();
    }

    /// <summary>
    /// Development logging minimal information
    /// </summary>
    /// <param name="builder"></param>
    public static void DevelopmentColored(WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) => 
            configuration.WriteTo.Console(
                restrictedToMinimumLevel: LogEventLevel.Information, 
                theme: AnsiConsoleTheme.Code));
    }

    public static void DevelopmentAlternate()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
            .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
            .CreateLogger();

    }
    /// <summary>
    /// Staging logging
    /// </summary>
    public static void Staging()
    {
        // TODO
    }

    /// <summary>
    /// Production logging
    /// </summary>
    public static void Production()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", "Log.txt"),
                rollingInterval: RollingInterval.Day)
            .CreateBootstrapLogger();
    }
}
