using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateAgencies(AeroSkullDbContext context)
    {
        if (context.Agencies.Any())
            return;

        context.Agencies.AddRange(
            new Agency()
            {
                Id = Guid.NewGuid(),
                Name = "Cuba Verde",
                Address = "Vedado, Habana",
                FaxNumber = 5500,
                Email = "verdeCuba@gmail.com"
            },
            new Agency()
            {
                Id = Guid.NewGuid(),
                Name = "Caribe Resorts",
                Address = "Playa, Habana",
                FaxNumber = 6000,
                Email = "caribe@gmail.com"
            },
            new Agency()
            {
                Id = Guid.NewGuid(),
                Name = "Wild Cuba",
                Address = "Vedado, Habana",
                FaxNumber = 1200,
                Email = "cubaWild@gmail.com"
            },
            new Agency()
            {
                Id = Guid.NewGuid(),
                Name = "Llave del Golfo",
                Address = "Varadero, Matanzas",
                FaxNumber = 3400,
                Email = "llave@gmail.com"
            },
            new Agency()
            {
                Id = Guid.NewGuid(),
                Name = "Green Paradise",
                Address = "Viñales, Pinar del Río",
                FaxNumber = 7800,
                Email = "paradise@gmail.com"
            },
            new Agency()
            {
                Id = Guid.NewGuid(),
                Name = "East Heights",
                Address = "Baracoa, Guantánamo",
                FaxNumber = 7800,
                Email = "eastHeights@gmail.com"
            }
        );

        context.SaveChanges();
    }
}