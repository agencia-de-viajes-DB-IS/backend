using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    public static void EnsurePopulate(this IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateAsyncScope().ServiceProvider.GetRequiredService<AeroSkullDbContext>();

        if (context.Database.GetPendingMigrations().Any
        ())
            context.Database.Migrate();

        PopulateAgencies(context);
        PopulateHotels(context);
        PopulateHotelDeals(context);
        PopulateExcursions(context);
        PopulateAgencyRelatedHotelDeals(context);
        PopulateExtendedExcursions(context);
        PopulatePackages(context);
    }
}