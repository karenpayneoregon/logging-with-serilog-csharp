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
}