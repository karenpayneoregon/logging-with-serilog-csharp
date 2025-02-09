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
            },

            new Citizen
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Smith",
                BirthDate = new DateOnly(1980, 5, 15),
                Since = new DateOnly(2010, 6, 1),
                Address = new Address
                {
                    Line1 = "456 Elm St",
                    Town = "Some town",
                    Country = "US",
                    Postcode = "67890"
                }
            },

            new Person
            {
                Id = 5,
                FirstName = "Alice",
                LastName = "Johnson",
                BirthDate = new DateOnly(2000, 3, 22),
                Address = new Address
                {
                    Line1 = "789 Oak St",
                    Town = "Other town",
                    Country = "UK",
                    Postcode = "54321"
                }
            },

            new Citizen
            {
                Id = 6,
                FirstName = "Bob",
                LastName = "Brown",
                BirthDate = new DateOnly(1975, 7, 30),
                Since = new DateOnly(2015, 8, 1),
                Address = new Address
                {
                    Line1 = "101 Pine St",
                    Town = "New town",
                    Country = "AU",
                    Postcode = "98765"
                }
            },

            new Person
            {
                Id = 7,
                FirstName = "Charlie",
                LastName = "Davis",
                BirthDate = new DateOnly(1995, 11, 5),
                Address = new Address
                {
                    Line1 = "202 Maple St",
                    Town = "Old town",
                    Country = "NZ",
                    Postcode = "87654"
                }
            },

            new Citizen
            {
                Id = 8,
                FirstName = "Diana",
                LastName = "Evans",
                BirthDate = new DateOnly(1985, 9, 12),
                Since = new DateOnly(2018, 10, 1),
                Address = new Address
                {
                    Line1 = "303 Birch St",
                    Town = "Big town",
                    Country = "ZA",
                    Postcode = "76543"
                }
            },

            new Person
            {
                Id = 9,
                FirstName = "Eve",
                LastName = "Foster",
                BirthDate = new DateOnly(1992, 4, 18),
                Address = new Address
                {
                    Line1 = "404 Cedar St",
                    Town = "Small town",
                    Country = "IN",
                    Postcode = "65432"
                }
            },

            new Citizen
            {
                Id = 10,
                FirstName = "Frank",
                LastName = "Green",
                BirthDate = new DateOnly(1970, 2, 25),
                Since = new DateOnly(2012, 3, 1),
                Address = new Address
                {
                    Line1 = "505 Walnut St",
                    Town = "Tiny town",
                    Country = "BR",
                    Postcode = "54321"
                }
            },

            new Person
            {
                Id = 11,
                FirstName = "Grace",
                LastName = "Harris",
                BirthDate = new DateOnly(1988, 6, 14),
                Address = new Address
                {
                    Line1 = "606 Chestnut St",
                    Town = "Huge town",
                    Country = "JP",
                    Postcode = "43210"
                }
            },

            new Citizen
            {
                Id = 12,
                FirstName = "Henry",
                LastName = "Irvine",
                BirthDate = new DateOnly(1998, 8, 21),
                Since = new DateOnly(2021, 9, 1),
                Address = new Address
                {
                    Line1 = "707 Spruce St",
                    Town = "Medium town",
                    Country = "DE",
                    Postcode = "32109"
                }
            }
        ];

        return people;
    }
}
