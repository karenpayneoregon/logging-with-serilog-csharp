using Serilog;

namespace WriteToDebugWindowApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        Log.Information("Just a simple message");
        Console.ReadLine();
    }
}
