using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TravelAgency.Infrastructure.Persistence;

public class BloggingContextFactory : IDesignTimeDbContextFactory<AeroSkullDbContext>
{
    public AeroSkullDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AeroSkullDbContext>();
        optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=limaCuba;Port=3306;Database=Aero_Skull");
        return new AeroSkullDbContext(optionsBuilder.Options);
    }
}