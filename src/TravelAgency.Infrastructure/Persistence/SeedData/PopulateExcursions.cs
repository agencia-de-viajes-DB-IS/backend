using TravelAgency.Domain.Entities;

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

        if(agencyIds.Count == 0)
            throw new Exception("There are no agencies");

        context.Excursions.AddRange(
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Habana Vieja",
                Price = 30,
                ArrivalDate = new DateTime(2024, 8, 15),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            },
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Cueva de Saturno",
                Price = 30,
                ArrivalDate = new DateTime(2024, 8, 20),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            },
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Guamá",
                Price = 50,
                ArrivalDate = new DateTime(2024, 9, 1),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            },
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Viñales",
                Price = 60,
                ArrivalDate = new DateTime(2024, 9, 15),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            },
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Pico Turquino",
                Price = 50,
                ArrivalDate = new DateTime(2024, 10, 14),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            },
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Varadero",
                Price = 70,
                ArrivalDate = new DateTime(2024, 8, 28),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            },
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Jardines del Rey",
                Price = 150,
                ArrivalDate = new DateTime(2024, 11, 23),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            },
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Cayo Largo",
                Price = 100,
                ArrivalDate = new DateTime(2024, 10, 5),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            },
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Trinidad",
                Price = 70,
                ArrivalDate = new DateTime(2024, 9, 10),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            },
            new Excursion()
            {
                Id = Guid.NewGuid(),
                Location = "Topes de Collantes",
                Price = 45,
                ArrivalDate = new DateTime(2024, 11, 1),
                AgencyId = agencyIds[random.Next(0, agencyIds.Count - 1)]
            }
        );

        context.SaveChanges();
    }
}