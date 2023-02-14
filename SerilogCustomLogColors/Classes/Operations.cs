using Bogus;
using SerilogCustomLogColors.Models;

namespace SerilogCustomLogColors.Classes;

public class Operations
{
    public static List<Student> GenerateStudents(int count = 5)
    {
        int identifier = 1;

        Faker<Student> prices = new Faker<Student>()
            .CustomInstantiator(f => new Student(identifier++))
            .RuleFor(student => student.FirstName, f => f.Person.FirstName)
            .RuleFor(student => student.LastName, f => f.Person.LastName)
            .RuleFor(student => student.Grade, f => f.Random.Int(1, 100));

        return prices.Generate(count);
    }

}
