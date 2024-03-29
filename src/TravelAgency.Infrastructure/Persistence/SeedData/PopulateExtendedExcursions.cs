using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static int _month = 8;
    private static void PopulateExtendedExcursions(AeroSkullDbContext context)
    {
        if (context.ExtendedExcursions.Any())
            return;

        var random = new Random(0);
        var agencyIds = context.Agencies
            .Select(agency => agency.Id)
            .ToList();

        var hotelDeals = context.HotelDeals.ToList();

        if (agencyIds.Count == 0)
            throw new Exception("There are no agencies");

        if (hotelDeals.Count == 0)
            throw new Exception("There are no hotel deals");

        // Intervals from August to December
        var stayIntervals = new List<Tuple<DateTime, DateTime>>();
        for (int i = 8; i <= 12; i++)
            stayIntervals.Add(new Tuple<DateTime, DateTime>(new DateTime(2024, i, 1), new DateTime(2024, i, 30)));

        var validHotelDeals = new List<List<HotelDeal>>();
        for (int i = 8; i <= 12; i++)
        {
            var list = new List<HotelDeal>();
            hotelDeals.Aggregate(list, AddValidIntervals);
            _month++;
            validHotelDeals.Add(list);
        }


        foreach (var agencyId in agencyIds)
        {
            context.ExtendedExcursions.AddRange(
            new ExtendedExcursion()
            {
                Id = Guid.NewGuid(),
                Name = "Viaje al Nicho",
                Description = "Lorem",
                Location = "El Nicho",
                Price = 60,
                ArrivalDate = new DateTime(2024, 8, 1),
                DepartureDate = new DateTime(2024, 8, 30),
                AgencyId = agencyId,
                HotelDeals = validHotelDeals[0]
            },
            new ExtendedExcursion()
            {
                Id = Guid.NewGuid(),
                Name = "Viaje al Cauto",
                Description = "Lorem",
                Location = "Río Cauto",
                Price = 65,
                ArrivalDate = new DateTime(2024, 9, 1),
                DepartureDate = new DateTime(2024, 9, 30),
                AgencyId = agencyId,
                HotelDeals = validHotelDeals[1]
            },
            new ExtendedExcursion()
            {
                Id = Guid.NewGuid(),
                Name = "Viaje al Pico Turquino",
                Description = "Lorem",
                Location = "Pico Turquino",
                Price = 100,
                ArrivalDate = new DateTime(2024, 10, 1),
                DepartureDate = new DateTime(2024, 10, 30),
                AgencyId = agencyId,
                HotelDeals = validHotelDeals[2]
            },
            new ExtendedExcursion()
            {
                Id = Guid.NewGuid(),
                Name = "Viaje a Cienfuegos",
                Description = "Lorem",
                Location = "Cienfuegos",
                Price = 80,
                ArrivalDate = new DateTime(2024, 11, 1),
                DepartureDate = new DateTime(2024, 11, 30),
                AgencyId = agencyId,
                HotelDeals = validHotelDeals[3]
            },
            new ExtendedExcursion()
            {
                Id = Guid.NewGuid(),
                Name = "Viaje a la Isla",
                Description = "Lorem",
                Location = "Isla de la Juventud",
                Price = 120,
                ArrivalDate = new DateTime(2024, 12, 1),
                DepartureDate = new DateTime(2024, 12, 30),
                AgencyId = agencyId,
                HotelDeals = validHotelDeals[4]
            }
        );
        }

        context.SaveChanges();
    }

    private static List<HotelDeal> AddValidIntervals(List<HotelDeal> hotelDeals, HotelDeal hotelDeal)
    {
        if (
            hotelDeal.ArrivalDate >= new DateTime(2024, _month, 1) && hotelDeal.DepartureDate <= new DateTime(2024, _month, 30) &&
            !hotelDeals.Any(deal =>
                (hotelDeal.ArrivalDate >= deal.ArrivalDate && hotelDeal.ArrivalDate <= deal.DepartureDate) ||
                (hotelDeal.DepartureDate >= deal.ArrivalDate && hotelDeal.DepartureDate <= deal.DepartureDate)))
            hotelDeals.Add(hotelDeal);
        return hotelDeals;
    }
}