namespace DestructuringSamples.Interfaces;

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