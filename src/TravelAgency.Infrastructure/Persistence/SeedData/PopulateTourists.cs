using TravelAgency.Domain.Entities;
using Bogus;
namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateTourist(AeroSkullDbContext context)
    {
        if (context.Tourists.Any())
            return;

        var testTourists = new Faker<Tourist>()
            .RuleFor(t => t.Id, f => f.Date.Past(20).ToString("yyMMdd") + f.Random.String2(5, "0123456789"))
            .RuleFor(t => t.FirstName, f => f.Person.FirstName)
            .RuleFor(t => t.LastName, f => f.Person.LastName)
            .RuleFor(t => t.Nationality, f => f.Address.Country())
            .Generate(10);

        context.Tourists.AddRange(testTourists);
        context.SaveChanges();
    }
}