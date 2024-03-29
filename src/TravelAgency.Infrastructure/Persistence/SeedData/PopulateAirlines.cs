using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateAirlines(AeroSkullDbContext context)
    {
        if (context.Airlines.Any())
            return;

        context.Airlines.AddRange(
            new Airline()
            {
                Id = Guid.NewGuid(),
                Name = "Air Europa"
            },
            new Airline()
            {
                Id = Guid.NewGuid(),
                Name = "Air Canada"
            },
            new Airline()
            {
                Id = Guid.NewGuid(),
                Name = "American Airline"
            },
            new Airline()
            {
                Id = Guid.NewGuid(),
                Name = "Cubana de Aviación"
            },
            new Airline()
            {
                Id = Guid.NewGuid(),
                Name = "Aeroflot"
            }
        );

        context.SaveChanges();
    }
}