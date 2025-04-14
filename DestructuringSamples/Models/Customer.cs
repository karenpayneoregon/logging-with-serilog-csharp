using DestructuringSamples.Interfaces;

namespace DestructuringSamples.Models;

public class Customer : ICustomer
{
    public int Id { get; set; }
    public string WorkTitle { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string OfficeEmail { get; set; }
    public string OfficePhoneNumber { get; set; }
}