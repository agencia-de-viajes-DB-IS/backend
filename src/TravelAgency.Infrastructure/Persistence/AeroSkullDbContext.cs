using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence;

public class AeroSkullDbContext : DbContext
{
    public AeroSkullDbContext(DbContextOptions<AeroSkullDbContext> options) : base(options) { }

    // This line allows us to create an SQL table Categories to represent Category C# class when migrating
    public DbSet<User> Users { get; set; }
}