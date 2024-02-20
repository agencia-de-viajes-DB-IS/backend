using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence;

public class AeroSkullDbContext : DbContext
{
    public AeroSkullDbContext(DbContextOptions<AeroSkullDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
}