using Serilog;
using static System.DateTime;
namespace WinFormsApp1.Classes;
public class SetupLogging
{

    public static void Development()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Debug()
            .WriteTo.File(Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, 
                    "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

    }

}