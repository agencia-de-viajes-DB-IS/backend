using System.Reflection;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulateAdmin(AeroSkullDbContext context)
    {
        var adminRoleId = context.Roles.Where(role => role.Name == "Super Admin").FirstOrDefault()!.Id;

        if (context.Users.Any(user => user.RoleId == adminRoleId))
            return;

        // TODO: this should be updated with the roles that are suppose to be 
        context.Users.Add(
            new User()
            {
                FirstName = "Sherlock",
                LastName = "Holmes",
                Email = "holmes@mail.net",
                Password = "adminPassword",
                RoleId = adminRoleId
            }
        );

        context.SaveChanges();
    }
}