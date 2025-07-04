using DestructuringSamples1.Models;

namespace DestructuringSamples1.Classes;

public static class MockedData
{
    public static List<Customer> Customers() =>
    [
        new Customer
        {
            Id = 1,
            WorkTitle = "Software Engineer",
            FirstName = "Alice",
            LastName = "Johnson",
            DateOfBirth = new DateOnly(1990, 5, 24),
            OfficeEmail = "alice.johnson@example.com",
            OfficePhoneNumber = "555-1234"
        },

        new Customer
        {
            Id = 2,
            WorkTitle = "Project Manager",
            FirstName = "Bob",
            LastName = "Smith",
            DateOfBirth = new DateOnly(1985, 3, 15),
            OfficeEmail = "bob.smith@example.com",
            OfficePhoneNumber = "555-5678"
        },

        new Customer
        {
            Id = 3,
            WorkTitle = "HR Specialist",
            FirstName = "Carol",
            LastName = "Williams",
            DateOfBirth = new DateOnly(1992, 11, 2),
            OfficeEmail = "carol.williams@example.com",
            OfficePhoneNumber = "555-9012"
        },

        new Customer
        {
            Id = 4,
            WorkTitle = "Sales Associate",
            FirstName = "David",
            LastName = "Brown",
            DateOfBirth = new DateOnly(1988, 7, 18),
            OfficeEmail = "david.brown@example.com",
            OfficePhoneNumber = "555-3456"
        },

        new Customer
        {
            Id = 5,
            WorkTitle = "Marketing Lead",
            FirstName = "Eve",
            LastName = "Davis",
            DateOfBirth = new DateOnly(1995, 1, 30),
            OfficeEmail = "eve.davis@example.com",
            OfficePhoneNumber = "555-7890"
        }
    ];
}