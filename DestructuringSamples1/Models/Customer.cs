using Destructurama.Attributed;
using DestructuringSamples1.Interfaces;

namespace DestructuringSamples1.Models;

public class Customer : ICustomer
{
    public int Id { get; set; }
    [NotLogged]
    public string WorkTitle { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    [NotLogged]
    public DateOnly DateOfBirth { get; set; }
    [NotLogged]
    public string OfficeEmail { get; set; }
    [NotLogged]
    public string OfficePhoneNumber { get; set; }
}