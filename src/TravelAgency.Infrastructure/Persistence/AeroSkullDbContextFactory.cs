using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TravelAgency.Infrastructure.Persistence;

public class AeroSkullContextFactory : IDesignTimeDbContextFactory<AeroSkullDbContext>
{
    public AeroSkullDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AeroSkullDbContext>();
        optionsBuilder.UseMySQL(args[0]);

        return new AeroSkullDbContext(optionsBuilder.Options);
    }
}