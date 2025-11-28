using DestructuringSamples.Classes;
using DestructuringSamples.Classes.Polices;
using Serilog;
using SpectreConsoleLibrary;

namespace DestructuringSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        LogFirstLastNamesWithPhone();

        ConfigureLoggerForIdFirstLastNames();

        ConfigureAndLogWithSocialSecurity();

        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }

    /// <summary>
    /// Logs customer details, specifically their first name, last name, and office phone number, 
    /// using a custom destructuring policy.
    /// </summary>
    /// <remarks>
    /// This method configures Serilog with the <see cref="FirstLastNamesWithPhonePolicy"/> 
    /// to customize how customer objects are logged. It then iterates through a mocked list of customers 
    /// and logs their details.
    /// </remarks>
    private static void LogFirstLastNamesWithPhone()
    {

        SpectreConsoleHelpers.PrintPink();
        
        AnsiConsole.MarkupLine("[hotpink]FirstName, LastName and office phone[/]");


        Log.Logger = new LoggerConfiguration()
            .Destructure.With(new FirstLastNamesWithPhonePolicy())
            .WriteTo.Console()
            .CreateLogger();

        foreach (var customer in MockedData.Customers())
        {
            Log.Information("Customers {@C}", customer);
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Configures the Serilog logger to destructure and log customer objects 
    /// with their <c>Id</c>, <c>FirstName</c>, and <c>LastName</c> properties.
    /// </summary>
    /// <remarks>
    /// This method utilizes the <see cref="IdentifierFirstLastNamesWithPolicy"/> 
    /// to customize the logging behavior for customer objects. It writes the 
    /// structured log output to the console.
    /// </remarks>
    private static void ConfigureLoggerForIdFirstLastNames()
    {
        
        SpectreConsoleHelpers.PrintPink();
        
        AnsiConsole.MarkupLine("[hotpink]Id,FirstName, LastName[/]");
        Log.Logger = new LoggerConfiguration()
            .Destructure.With(new IdentifierFirstLastNamesWithPolicy())
            .WriteTo.Console()
            .CreateLogger();


        foreach (var customer in MockedData.Customers())
        {
            Log.Information("Customers {@C}", customer);
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Configures the logger to include a custom destructuring policy for handling customer data
    /// with social security numbers and logs the structured data of customers.
    /// </summary>
    /// <remarks>
    /// This method uses the <see cref="SocialSecurityIdentifierFirstLastNamesWithPolicy"/> to extract
    /// and log the customer's identifier, first name, last name, and social security number.
    /// </remarks>
    private static void ConfigureAndLogWithSocialSecurity()
    {
        
        SpectreConsoleHelpers.PrintPink();
        
        AnsiConsole.MarkupLine("[hotpink]Id,FirstName, LastName, SocialSecurityNumber[/]");
        Log.Logger = new LoggerConfiguration()
            .Destructure.With(new SocialSecurityIdentifierFirstLastNamesWithPolicy())
            .WriteTo.Console()
            .CreateLogger();


        foreach (var customer in MockedData.Customers())
        {
            Log.Information("Customers {@C}", customer);
        }
    }
}