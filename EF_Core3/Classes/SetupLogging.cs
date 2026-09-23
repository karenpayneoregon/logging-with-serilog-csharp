using Serilog;
using Serilog.Events;
namespace EF_Core3.Classes;

public class SetupLogging
{
    /// <summary>
    /// Configures Serilog logging for the application.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> used to configure the application's services and middleware.
    /// </param>
    /// <remarks>
    /// This method sets up Serilog as the logging provider, specifying logging levels, output destinations,
    /// and formatting. It overrides the default logging levels for "Microsoft" and "System" namespaces
    /// to <see cref="LogEventLevel.Warning"/> and sets the default logging level to <see cref="LogEventLevel.Information"/>.
    /// Logs are written to both the console and a file located in the "LogFiles" directory.
    /// </remarks>
    public static void Other(WebApplicationBuilder builder)
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles",
                    $"{DateTime.Now.Year}-{DateTime.Now.Month:d2}-{DateTime.Now.Day:d2}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

        builder.Host.UseSerilog(); ;
    }
}