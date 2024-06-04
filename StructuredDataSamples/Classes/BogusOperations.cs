using Bogus;
using Bogus.DataSets;
using StructuredDataSamples.Models;

namespace StructuredDataSamples.Classes;

public class BogusOperations
{
    public static List<Customer> PeopleList(int count = 5)
    {

        Randomizer.Seed = new Random(33);
        var id = 1;

        var faker = new Faker<Customer>()
            .RuleFor(t => t.Id, f => id++)
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.FirstName, (f, u) => f.Name.FirstName((Name.Gender?)u.Gender))
            .RuleFor(t => t.LastName, f => f.Name.LastName())
            .RuleFor(t => t.BirthDate, f => f.Date.BetweenDateOnly(new DateOnly(1899, 1, 1), new DateOnly(1999, 1, 1)))
            .RuleFor(c => c.Gender, f => f.PickRandom<Gender>());


        return faker.Generate(count);

    }
}