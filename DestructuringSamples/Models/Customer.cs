namespace DestructuringSamples.Models;

public interface ICustomer
{
    int Id { get; set; }
    string WorkTitle { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    DateOnly DateOfBirth { get; set; }
    string OfficeEmail { get; set; }
    string OfficePhoneNumber { get; set; }
}

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