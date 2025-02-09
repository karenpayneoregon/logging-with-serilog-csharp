using Serilog;
using SerilogFiltering.Models;

namespace SerilogFiltering.Interfaces;

public interface IPerson : IFormattable
{
    private static readonly ILogger Logger = Log.ForContext("Category", nameof(IPerson));
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    DateOnly BirthDate { get; set; }
    Address Address { get; set; }
    /// <summary>
    /// Logs the details of the person, including their ID, first name, last name, 
    /// birthdate, and country of residence, using the configured Serilog logger.
    /// </summary>
    /// <remarks>
    /// This method formats and logs the person's details in a structured manner. 
    /// Ensure that the Serilog logger is properly configured to capture and display 
    /// the log information.
    ///
    /// Note: Normally we use the commented out code below, but for this example, formating is used
    /// </remarks>
    public void LogDetails()
    {
        //Logger.Information("Person First: {firstName}, Last: {lastName}", FirstName, LastName);
        Logger.Information($"{Id,-5}{FirstName,-15}{LastName,-15}{BirthDate,-12:MM/dd/yyyy}{Address.Country}");
    }
}