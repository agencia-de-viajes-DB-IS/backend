using System.Reflection;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence.SeedData;

public static partial class SeedData
{
    private static void PopulatePackages(AeroSkullDbContext context)
    {
        if (context.Packages.Any())
            return;

        var random = new Random();
        for(int i = 8; i <= 12; i++)
        {
            context.Packages.Add(
                new Package()
                {
                    Code = Guid.NewGuid(),
                    Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Esse iusto non ut delectus maxime quod cupiditate reprehenderit ad maiores voluptatem, ea labore, commodi incidunt in nisi velit facilis recusandae impedit.",
                    Price = random.Next(50, 150),
                    ArrivalDate = new DateTime(2024, i, 1),
                    DepartureDate = new DateTime(2024, i, 30)
                }
            );
        }

        context.SaveChanges();
    }
}