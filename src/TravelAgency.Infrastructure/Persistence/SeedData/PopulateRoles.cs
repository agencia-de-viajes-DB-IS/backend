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
                        Permissions.ReadUsers, 
                        Permissions.ReadExcursions,
                        Permissions.WriteExcursions
                    }
                }
            );

        context.SaveChanges();
    }
}