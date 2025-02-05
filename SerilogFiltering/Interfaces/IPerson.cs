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
    /// Logs the details of the person, including their first name and last name, 
    /// using the configured Serilog logger.
    /// </summary>
    /// <remarks>
    /// This method utilizes structured logging to output the person's first and last name.
    /// Ensure that the logger is properly configured to capture and display the log information.
    /// </remarks>
    public void LogDetails()
    {
        Logger.Information("Person First: {firstName}, Last: {lastName}",
            FirstName, LastName);
    }
}