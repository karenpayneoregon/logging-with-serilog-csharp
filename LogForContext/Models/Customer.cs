using LogForContext.Classes;

namespace LogForContext.Models;

public class Customer
{
    private static Serilog.ILogger Log => Serilog.Log.ForContext<Customer>();

    public static void DoSomething()
    {
        Log.Here().Information("Hello, world!");
    }
}