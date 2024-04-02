using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TravelAgency.Infrastructure.Persistence;

public class AeroSkullContextFactory : IDesignTimeDbContextFactory<AeroSkullDbContext>
{
    public AeroSkullDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AeroSkullDbContext>();
        optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=BritoAlv.2002;Port=3306;Database=Aero_Skull");

        return new AeroSkullDbContext(optionsBuilder.Options);
    }
}