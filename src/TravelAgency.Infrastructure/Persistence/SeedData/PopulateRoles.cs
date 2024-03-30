using System.Reflection;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateRoles(AeroSkullDbContext context)
    {
        if (context.Roles.Any())
            return;

        // TODO: this should be updated with the roles that are suppose to be 
        context.Roles.Add(
            new Role()
            {
                Name = "Customer",
                Permissions = [
                    Permissions.ReadExcursions,
                    Permissions.ReadPackages,
                    Permissions.ReadAgencies,
                    Permissions.ReadHotels,
                    Permissions.ReadHotelDeals,
                    Permissions.ReadPackages
                ]
            }
        );
        context.Roles.Add(
            new Role()
            {
                Name = "Marketing Agent",
                Permissions = [
                    Permissions.WriteUsers
                ]
            }
        );

        context.Roles.Add(
            new Role()
            {
                Name = "Super Admin",
                Permissions = new List<Permissions>(){
                        Permissions.WriteUsers,
                        Permissions.WriteExcursions,
                        Permissions.WritePackages,
                        Permissions.WriteRoles,
                        Permissions.WriteTourists,
                        Permissions.WriteFacilities,
                        Permissions.WritePackageReservation,
                        Permissions.WriteAgencies,

                        Permissions.ReadAgencies,
                        Permissions.ReadHotels,
                        Permissions.ReadHotelDeals,
                        Permissions.ReadPackages,
                        Permissions.ReadExcursions,
                        Permissions.ReadUsers,
                        Permissions.ReadRoles,
                        Permissions.ReadAirlines,
                        Permissions.ReadTourists,
                        Permissions.ReadFacilities,
                        Permissions.ReadPackageReservation,
                }
            }
        );

        context.SaveChanges();
    }
}