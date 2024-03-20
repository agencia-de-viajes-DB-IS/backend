using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateHotels(AeroSkullDbContext context)
    {
        if (context.Hotels.Any())
            return;

        context.Hotels.AddRange(
            new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Parque Central",
                Address = "Centrohabana, Habana",
                Category = 5
            },
            new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Paseo del Prado",
                Address = "Centrohabana, Habana",
                Category = 5
            },
            new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Hotel Nacional",
                Address = "Vedado, Habana",
                Category = 5
            },
            new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Internacional",
                Address = "Varadero, Matanzas",
                Category = 5
            },
            new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Viñales",
                Address = "Viñales, Pinar del Río",
                Category = 5
            },
            new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Baracoa",
                Address = "Baracoa, Guantánamo",
                Category = 5
            }
        );

        context.SaveChanges();
    }
}