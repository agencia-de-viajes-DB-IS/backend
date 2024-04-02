using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TravelAgency.Infrastructure.Persistence;

public class AeroSkullContextFactory : IDesignTimeDbContextFactory<AeroSkullDbContext>
{
    public AeroSkullDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AeroSkullDbContext>();
        optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=your_password;Port=3306;Database=Aero_Skull");

        return new AeroSkullDbContext(optionsBuilder.Options);
    }
}