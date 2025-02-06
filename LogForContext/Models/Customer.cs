using LogForContext.Classes;

namespace LogForContext.Models;

public class Customer
{
    /// <summary>
    /// Gets a Serilog logger instance configured with the context of the <see cref="Customer"/> class.
    /// </summary>
    /// <remarks>
    /// This logger is statically scoped to the <see cref="Customer"/> class and can be used to log messages
    /// with additional context, such as the member name, file path, and line number, when used with the
    /// <see cref="LoggerExtensions.Here"/> extension method.
    /// </remarks>
    private static Serilog.ILogger Log => Serilog.Log.ForContext<Customer>();

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
}