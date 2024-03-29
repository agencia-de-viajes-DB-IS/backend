using TravelAgency.Domain.Entities;
using Bogus;
namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateAgencies(AeroSkullDbContext context)
    {
        if (context.Agencies.Any())
            return;

        var testAgencies = new Faker<Agency>()
            .RuleFor(a => a.Id, f => f.Random.Guid())
            .RuleFor(a => a.Name, f => f.PickRandom(new List<string> { "Cuba Verde", "Caribe Resorts", "Havana Tours", "Varadero Vacations", "Trinidad Travel" }))
            .RuleFor(a => a.Address, f => f.PickRandom(new List<string> { "Vedado, Habana", "Playa, Habana", "Centro, Varadero", "Historic Center, Trinidad", "Downtown, Cienfuegos" }))
            .RuleFor(a => a.FaxNumber, f => f.Random.Int(1000, 9999))
            .RuleFor(a => a.Email, f => f.Internet.Email())
            .Generate(10);

        context.Agencies.AddRange(testAgencies);
        context.SaveChanges();
    }
}