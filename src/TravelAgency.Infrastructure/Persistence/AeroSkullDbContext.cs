using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Persistence;

public class AeroSkullDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Tourist> Tourists { get; set; }
    public DbSet<PackageReservation> PackageReservations { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<HotelDealReservation> HotelDealReservations { get; set; }
    public DbSet<HotelDeal> HotelDeals { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<ExtendedExcursion> ExtendedExcursions { get; set; }
    public DbSet<ExcursionReservation> ExcursionReservations { get; set; }
    public DbSet<Excursion> Excursions { get; set; }
    public DbSet<AgencyRelatedHotelDeal> AgencyRelatedHotelDeals { get; set; }
    public DbSet<Agency> Agencies { get; set; }

    public AeroSkullDbContext(DbContextOptions<AeroSkullDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExtendedExcursion>().ToTable("ExtendedExcursions");

        modelBuilder.Entity<User>()
            .OwnsOne(user => user.Role);
    
        modelBuilder.Entity<HotelDeal>()
            .HasIndex(hotelDeal => new
            {
                hotelDeal.Id,
                hotelDeal.HotelId
            })
            .IsUnique();

        modelBuilder.Entity<AgencyRelatedHotelDeal>()
        .HasIndex(hotelDeal => new
        {
            hotelDeal.AgencyId,
            hotelDeal.HotelDealId
        })
        .IsUnique();

        modelBuilder.Entity<HotelDealReservation>()
        .HasIndex(reservation => new
        {
            reservation.AgencyRelatedHotelDealId,
            reservation.UserId,
        })
        .IsUnique();

        modelBuilder.Entity<ExcursionReservation>()
        .HasIndex(reservation => new
        {
            reservation.UserId,
            reservation.ExcursionId
        })
        .IsUnique();

        modelBuilder.Entity<PackageReservation>()
        .HasIndex(reservation => new
        {
            reservation.AgencyId,
            reservation.UserId,
            reservation.PackageId
        })
        .IsUnique();
    }
}