using TravelAgency.Domain.Entities;
using Bogus;
namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateExcursions(AeroSkullDbContext context)
    {
        if (context.Excursions.Any())
            return;

        var random = new Random(0);
        var agencyIds = context.Agencies
            .Select(agency => agency.Id)
            .ToList();

        if (agencyIds.Count == 0)
            throw new Exception("There are no agencies");


        var testExcursions = new Faker<Excursion>()
            .RuleFor(e => e.Id, f => f.Random.Guid())
            .RuleFor(e => e.Name, f => f.PickRandom(new List<string> { "Havana Day Trip", "Varadero Beach Excursion", "Trinidad History Tour", "Cienfuegos City Tour", "Santa Clara Revolution Tour" }))
            .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
            .RuleFor(e => e.Location, f => f.PickRandom(new List<string> { "Havana", "Varadero", "Trinidad", "Cienfuegos", "Santa Clara" }))
            .RuleFor(e => e.Price, f => f.Random.Decimal(10, 100))
            .RuleFor(e => e.ArrivalDate, f => f.Date.Between(new DateTime(2024, 9, 1), new DateTime(2026, 12, 31)))
            .RuleFor(e => e.AgencyId, f => f.PickRandom(agencyIds))
            .RuleFor(a => a.Capacity, f => f.Random.Int(5, 30))
            .Generate(10);

        context.Excursions.AddRange(testExcursions);
        context.SaveChanges();
        context.SaveChanges();
    }
}