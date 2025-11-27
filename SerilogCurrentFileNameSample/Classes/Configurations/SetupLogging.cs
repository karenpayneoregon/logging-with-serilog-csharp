using Microsoft.Extensions.Configuration;
using Serilog;


namespace SerilogCurrentFileNameSample.Classes.Configurations;
internal class SetupLogging
{
    /// <summary>
    /// Configures Serilog for development purposes with verbose logging and file-based output.
    /// </summary>
    /// <remarks>
    /// This method initializes the Serilog logger with a verbose logging level and writes logs to a file.
    /// The log file name is retrieved from the application's configuration using 
    /// <see cref="ConfigurationHelpers.GetSerilogFileName"/>.
    /// Logs are written with a rolling interval of one minute and include a detailed output template.
    /// </remarks>
    public static void Development()
    {
        var fileName = ConfigurationHelpers.GetSerilogFileName();
        
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()

            .WriteTo.File(fileName,
                rollingInterval: RollingInterval.Minute,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

    }
}
