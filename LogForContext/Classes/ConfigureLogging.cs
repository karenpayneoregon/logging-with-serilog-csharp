using Serilog;
using System.IO;
using static System.DateTime;

namespace LogForContext.Classes;
public class ConfigureLogging
{
    /// <summary>
    /// Setup SeriLog to create a new folder per day with a single log file.
    /// </summary>
    /// <param name="folder">Base folder to write log files</param>
    public static void Development(string folder)
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File(Path.Combine(folder, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }
}
