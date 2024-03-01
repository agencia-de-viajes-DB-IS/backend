using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateAgencyRelatedHotelDeals(AeroSkullDbContext context)
    {
        if (context.AgencyRelatedHotelDeals.Any())
            return;

        var agencyIds = context.Agencies
            .Select(agency => agency.Id)
            .ToList();

        var hotelDealsIds = context.HotelDeals
            .Select(hotelDeal => hotelDeal.Id)
            .ToList();

        foreach(var agencyId in agencyIds)
        {
            foreach(var hotelDealId in hotelDealsIds)
            {
                context.AgencyRelatedHotelDeals.Add(
                    new AgencyRelatedHotelDeal()
                    {
                        Id = Guid.NewGuid(),
                        AgencyId = agencyId,
                        HotelDealId = hotelDealId
                    }
                );
            }
        }

        context.SaveChanges();
    }
}