using Serilog;
using Serilog.Core;
using SerilogFiltering.Interfaces;

namespace SerilogFiltering.Models;

public class Citizen : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateOnly Since { get; set; }
    public Address Address { get; set; }
    string IFormattable.ToString(string format, IFormatProvider formatProvider)
        => $"{FirstName} {LastName}";

    private static readonly ILogger Logger = Log.ForContext("Category", nameof(IPerson));
    public void LogDetails()
    {
        Logger.Information($"{Id,-5}{FirstName,-15}{LastName,-15}{BirthDate,-12:MM/dd/yyyy}{Since,-12:MM/dd/yyyy}{Address.Country}");
    }
}