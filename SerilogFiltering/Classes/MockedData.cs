using SerilogFiltering.Interfaces;
using SerilogFiltering.Models;

namespace SerilogFiltering.Classes;
public class MockedData
{
    public static List<IPerson> List()
    {
        List<IPerson> people =
        [
            new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateOnly(1790, 12, 1),
                Address = new Address
                {
                    Line1 = "123 Main St",
                    Line2 = "Apt 101",
                    Town = "Any town",
                    Country = "US",
                    Postcode = "12345"
                }
            },

            new Citizen
            {
                Id = 2,
                FirstName = "Anne",
                LastName = "Doe",
                BirthDate = new DateOnly(1969, 1, 11),
                Since = new DateOnly(2020, 1, 1),
                Address = new Address
                {
                    Line2 = "Apt 101",
                    Town = "Any town",
                    Country = "CA"
                }
            },
            new Person
            {
                Id = 3,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateOnly(1990, 12, 1),
                Address = new Address
                {
                    Line1 = "123 Main St",
                    Line2 = "Apt 101",
                    Town = "Any town",
                    Country = "MG",
                    Postcode = "12345"
                }
            }
        ];
        return people;
    }
}
