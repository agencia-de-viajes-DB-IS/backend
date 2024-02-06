using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Persistence.Models;

public partial class AeroSkullContext : DbContext
{
    public AeroSkullContext(DbContextOptions<AeroSkullContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agency> Agencies { get; set; }

    public virtual DbSet<Excursion> Excursions { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<GroupReservation> GroupReservations { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelDeal> HotelDeals { get; set; }

    public virtual DbSet<IndividualReservation> IndividualReservations { get; set; }

    public virtual DbSet<IndividualReservationHotel> IndividualReservationHotels { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Tourist> Tourists { get; set; }

    public virtual DbSet<Touristgroup> Touristgroups { get; set; }

    public virtual DbSet<User> Users { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=limaCuba;Port=3306;Database=Aero_Skull");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("agency");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Fax)
                .HasMaxLength(255)
                .HasColumnName("fax");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasMany(d => d.Excursions).WithMany(p => p.Agencies)
                .UsingEntity<Dictionary<string, object>>(
                    "AgencyWorksWithExcursion",
                    r => r.HasOne<Excursion>().WithMany()
                        .HasForeignKey("ExcursionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("agency_works_with_excursions_ibfk_2"),
                    l => l.HasOne<Agency>().WithMany()
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("agency_works_with_excursions_ibfk_1"),
                    j =>
                    {
                        j.HasKey("AgencyId", "ExcursionId").HasName("PRIMARY");
                        j.ToTable("agency_works_with_excursions");
                        j.HasIndex(new[] { "ExcursionId" }, "excursionId");
                        j.IndexerProperty<string>("AgencyId").HasColumnName("agencyId");
                        j.IndexerProperty<string>("ExcursionId").HasColumnName("excursionId");
                    });

            entity.HasMany(d => d.Hotels).WithMany(p => p.Agencies)
                .UsingEntity<Dictionary<string, object>>(
                    "AgencyWorksWithHotel",
                    r => r.HasOne<Hotel>().WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("agency_works_with_hotel_ibfk_2"),
                    l => l.HasOne<Agency>().WithMany()
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("agency_works_with_hotel_ibfk_1"),
                    j =>
                    {
                        j.HasKey("AgencyId", "HotelId").HasName("PRIMARY");
                        j.ToTable("agency_works_with_hotel");
                        j.HasIndex(new[] { "HotelId" }, "hotelId");
                        j.IndexerProperty<string>("AgencyId").HasColumnName("agencyId");
                        j.IndexerProperty<string>("HotelId").HasColumnName("hotelId");
                    });

            entity.HasMany(d => d.Tourists).WithMany(p => p.Agencies)
                .UsingEntity<Dictionary<string, object>>(
                    "AgencyWorksWithTourist",
                    r => r.HasOne<Tourist>().WithMany()
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("agency_works_with_tourist_ibfk_2"),
                    l => l.HasOne<Agency>().WithMany()
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("agency_works_with_tourist_ibfk_1"),
                    j =>
                    {
                        j.HasKey("AgencyId", "TouristId").HasName("PRIMARY");
                        j.ToTable("agency_works_with_tourist");
                        j.HasIndex(new[] { "TouristId" }, "touristId");
                        j.IndexerProperty<string>("AgencyId").HasColumnName("agencyId");
                        j.IndexerProperty<string>("TouristId").HasColumnName("touristId");
                    });
        });

        modelBuilder.Entity<Excursion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("excursion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArrivalDate)
                .HasColumnType("date")
                .HasColumnName("arrival_date");
            entity.Property(e => e.ArrivalPlace)
                .HasMaxLength(255)
                .HasColumnName("arrival_place");
            entity.Property(e => e.DepartureDate)
                .HasColumnType("date")
                .HasColumnName("departure_date");
            entity.Property(e => e.DeparturePlace)
                .HasMaxLength(255)
                .HasColumnName("departure_place");

            entity.HasMany(d => d.Hotels).WithMany(p => p.Excursions)
                .UsingEntity<Dictionary<string, object>>(
                    "ExcursionAssociatedHotel",
                    r => r.HasOne<Hotel>().WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("excursion_associated_hotel_ibfk_2"),
                    l => l.HasOne<Excursion>().WithMany()
                        .HasForeignKey("ExcursionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("excursion_associated_hotel_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ExcursionId", "HotelId").HasName("PRIMARY");
                        j.ToTable("excursion_associated_hotel");
                        j.HasIndex(new[] { "HotelId" }, "hotelId");
                        j.IndexerProperty<string>("ExcursionId").HasColumnName("excursionId");
                        j.IndexerProperty<string>("HotelId").HasColumnName("hotelId");
                    });
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("facility");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasMany(d => d.Packages).WithMany(p => p.Facilities)
                .UsingEntity<Dictionary<string, object>>(
                    "PackageHasFacility",
                    r => r.HasOne<Package>().WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("package_has_facilities_ibfk_2"),
                    l => l.HasOne<Facility>().WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("package_has_facilities_ibfk_1"),
                    j =>
                    {
                        j.HasKey("FacilityId", "PackageId").HasName("PRIMARY");
                        j.ToTable("package_has_facilities");
                        j.HasIndex(new[] { "PackageId" }, "packageId");
                        j.IndexerProperty<string>("FacilityId").HasColumnName("facilityId");
                        j.IndexerProperty<string>("PackageId").HasColumnName("packageId");
                    });
        });

        modelBuilder.Entity<GroupReservation>(entity =>
        {
            entity.HasKey(e => new { e.AgencyId, e.GroupId, e.ReservationDate }).HasName("PRIMARY");

            entity.ToTable("group_reservation");

            entity.HasIndex(e => e.ExcursionId, "excursionId");

            entity.HasIndex(e => e.GroupId, "groupId");

            entity.HasIndex(e => e.PackageId, "packageId");

            entity.Property(e => e.AgencyId).HasColumnName("agencyId");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.ReservationDate)
                .HasColumnType("date")
                .HasColumnName("reservation_date");
            entity.Property(e => e.AeroCompany)
                .HasMaxLength(255)
                .HasColumnName("aero_company");
            entity.Property(e => e.DepartureDate)
                .HasColumnType("date")
                .HasColumnName("departure_date");
            entity.Property(e => e.ExcursionId).HasColumnName("excursionId");
            entity.Property(e => e.PackageId).HasColumnName("packageId");
            entity.Property(e => e.ParticipantsAmount).HasColumnName("participants_amount");
            entity.Property(e => e.Price)
                .HasPrecision(15)
                .HasColumnName("price");

            entity.HasOne(d => d.Agency).WithMany(p => p.GroupReservations)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("group_reservation_ibfk_1");

            entity.HasOne(d => d.Excursion).WithMany(p => p.GroupReservations)
                .HasForeignKey(d => d.ExcursionId)
                .HasConstraintName("group_reservation_ibfk_4");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupReservations)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("group_reservation_ibfk_2");

            entity.HasOne(d => d.Package).WithMany(p => p.GroupReservations)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("group_reservation_ibfk_3");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hotel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<HotelDeal>(entity =>
        {
            entity.HasKey(e => new { e.DealId, e.HotelId }).HasName("PRIMARY");

            entity.ToTable("hotel_deals");

            entity.HasIndex(e => e.HotelId, "hotelId");

            entity.Property(e => e.DealId).HasColumnName("dealId");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasPrecision(15)
                .HasColumnName("price");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelDeals)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hotel_deals_ibfk_1");
        });

        modelBuilder.Entity<IndividualReservation>(entity =>
        {
            entity.HasKey(e => new { e.AgencyId, e.TouristId, e.ReservationDate }).HasName("PRIMARY");

            entity.ToTable("individual_reservation");

            entity.HasIndex(e => e.ExcursionId, "excursionId");

            entity.HasIndex(e => e.ReservationDate, "reservation_date");

            entity.HasIndex(e => e.TouristId, "touristId");

            entity.Property(e => e.AgencyId).HasColumnName("agencyId");
            entity.Property(e => e.TouristId).HasColumnName("touristId");
            entity.Property(e => e.ReservationDate)
                .HasColumnType("date")
                .HasColumnName("reservation_date");
            entity.Property(e => e.ExcursionId).HasColumnName("excursionId");

            entity.HasOne(d => d.Agency).WithMany(p => p.IndividualReservations)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("individual_reservation_ibfk_1");

            entity.HasOne(d => d.Excursion).WithMany(p => p.IndividualReservations)
                .HasForeignKey(d => d.ExcursionId)
                .HasConstraintName("individual_reservation_ibfk_2");

            entity.HasOne(d => d.Tourist).WithMany(p => p.IndividualReservations)
                .HasForeignKey(d => d.TouristId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("individual_reservation_ibfk_3");
        });

        modelBuilder.Entity<IndividualReservationHotel>(entity =>
        {
            entity.HasKey(e => new { e.AgencyId, e.TouristId, e.ReservationDate, e.HotelId }).HasName("PRIMARY");

            entity.ToTable("individual_reservation_hotels");

            entity.HasIndex(e => e.HotelId, "hotelId");

            entity.HasIndex(e => e.ReservationDate, "reservation_date");

            entity.HasIndex(e => e.TouristId, "touristId");

            entity.Property(e => e.AgencyId).HasColumnName("agencyId");
            entity.Property(e => e.TouristId).HasColumnName("touristId");
            entity.Property(e => e.ReservationDate)
                .HasColumnType("date")
                .HasColumnName("reservation_date");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.ArrivalDate)
                .HasColumnType("date")
                .HasColumnName("arrival_date");

            entity.HasOne(d => d.Agency).WithMany(p => p.IndividualReservationHotels)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("individual_reservation_hotels_ibfk_1");

            entity.HasOne(d => d.Hotel).WithMany(p => p.IndividualReservationHotels)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("individual_reservation_hotels_ibfk_4");

            entity.HasOne(d => d.Tourist).WithMany(p => p.IndividualReservationHotels)
                .HasForeignKey(d => d.TouristId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("individual_reservation_hotels_ibfk_3");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PRIMARY");

            entity.ToTable("package");

            entity.HasIndex(e => e.ExcursionId, "excursionId");

            entity.Property(e => e.PackageId).HasColumnName("packageId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.ExcursionId).HasColumnName("excursionId");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PackageCode)
                .HasMaxLength(255)
                .HasColumnName("packageCode");

            entity.HasOne(d => d.Excursion).WithMany(p => p.Packages)
                .HasForeignKey(d => d.ExcursionId)
                .HasConstraintName("package_ibfk_1");
        });

        modelBuilder.Entity<Tourist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tourist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nationality)
                .HasMaxLength(255)
                .HasColumnName("nationality");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Tourist)
                .HasForeignKey<Tourist>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tourist_ibfk_1");
        });

        modelBuilder.Entity<Touristgroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("touristgroup");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasMany(d => d.Tourists).WithMany(p => p.Groups)
                .UsingEntity<Dictionary<string, object>>(
                    "TouristBelongsToGroup",
                    r => r.HasOne<Tourist>().WithMany()
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tourist_belongs_to_group_ibfk_2"),
                    l => l.HasOne<Touristgroup>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tourist_belongs_to_group_ibfk_1"),
                    j =>
                    {
                        j.HasKey("GroupId", "TouristId").HasName("PRIMARY");
                        j.ToTable("tourist_belongs_to_group");
                        j.HasIndex(new[] { "TouristId" }, "touristId");
                        j.IndexerProperty<string>("GroupId").HasColumnName("groupId");
                        j.IndexerProperty<string>("TouristId").HasColumnName("touristId");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
