using LogForContext.Classes;

namespace LogForContext.Models;

public class Person
{
    /// <summary>
    /// Gets a logger instance configured with the context of the <see cref="Person"/> class.
    /// </summary>
    /// <remarks>
    /// This property provides a static <see cref="Serilog.ILogger"/> instance that is pre-configured
    /// with the context of the <see cref="Person"/> class, enabling structured logging with additional
    /// contextual information.
    /// </remarks>
    private static Serilog.ILogger Log => Serilog.Log.ForContext<Person>();

    /// <summary>
    /// Logs an informational message indicating that the method has been invoked.
    /// </summary>
    /// <remarks>
    /// This method uses a Serilog logger configured with contextual information
    /// about the calling member, file path, and line number.
    /// </remarks>
    public static void DoSomething()
    {
        Log.Here().Information("Hello, world!");
    }

    /// <summary>
    /// Logs an informational message indicating that the <c>SomethingElse</c> method has been invoked.
    /// </summary>
    /// <remarks>
    /// This method utilizes a Serilog logger configured with contextual information
    /// about the calling member, file path, and line number.
    /// </remarks>
    public static void SomethingElse()
    {
        Log.Here().Information("Hello, world!");
    }
}