using Serilog;
namespace WriteToDebugWindowApp.Classes;
public class SetupLogging
{

    public static void Development()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Debug()
            .CreateLogger();
    }

}