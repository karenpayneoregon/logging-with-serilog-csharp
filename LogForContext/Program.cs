using LogForContext.Classes;
using LogForContext.Models;
using Serilog;
using Serilog.Core;

namespace LogForContext;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        SetupLogging.Development();

        var personContext = Log.ForContext<Person>();
        personContext.Information("Hello from person");

        var customerContext = Log.ForContext<Customer>();
        customerContext.Information("Hello from customer");

        Customer.DoSomething();


    }
}