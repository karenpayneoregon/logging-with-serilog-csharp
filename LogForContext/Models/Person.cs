using LogForContext.Classes;

namespace LogForContext.Models;

public class Person
{
    private static Serilog.ILogger Log => Serilog.Log.ForContext<Person>();

    public static void DoSomething()
    {
        Log.Here().Information("Hello, world!");
    }

    public static void SomethingElse()
    {
        Log.Here().Information("Hello, world!");
    }
}