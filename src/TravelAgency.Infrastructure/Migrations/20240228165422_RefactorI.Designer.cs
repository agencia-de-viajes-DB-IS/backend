﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgency.Infrastructure.Persistence;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    [DbContext(typeof(AeroSkullDbContext))]
    [Migration("20240228165422_RefactorI")]
    partial class RefactorI
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ExcursionReservationTourist", b =>
                {
                    b.Property<Guid>("ExcursionReservationsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TouristsId")
                        .HasColumnType("char(36)");

                    b.HasKey("ExcursionReservationsId", "TouristsId");

                    b.HasIndex("TouristsId");

                    b.ToTable("ExcursionReservationTourist");
                });

            modelBuilder.Entity("ExtendedExcursionHotelDeal", b =>
                {
                    b.Property<Guid>("ExtendedExcursionsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("HotelDealsId")
                        .HasColumnType("char(36)");

                    b.HasKey("ExtendedExcursionsId", "HotelDealsId");

                    b.HasIndex("HotelDealsId");

                    b.ToTable("ExtendedExcursionHotelDeal");
                });

            modelBuilder.Entity("ExtendedExcursionPackage", b =>
                {
                    b.Property<Guid>("ExtendedExcursionsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PackagesCode")
                        .HasColumnType("char(36)");

                    b.HasKey("ExtendedExcursionsId", "PackagesCode");

                    b.HasIndex("PackagesCode");

                    b.ToTable("ExtendedExcursionPackage");
                });

            modelBuilder.Entity("FacilityPackage", b =>
                {
                    b.Property<int>("FacilitiesId")
                        .HasColumnType("int");

                    b.Property<Guid>("PackagesCode")
                        .HasColumnType("char(36)");

                    b.HasKey("FacilitiesId", "PackagesCode");

                    b.HasIndex("PackagesCode");

                    b.ToTable("FacilityPackage");
                });

            modelBuilder.Entity("HotelDealReservationTourist", b =>
                {
                    b.Property<Guid>("HotelDealReservationsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TouristsId")
                        .HasColumnType("char(36)");

                    b.HasKey("HotelDealReservationsId", "TouristsId");

                    b.HasIndex("TouristsId");

                    b.ToTable("HotelDealReservationTourist");
                });

            modelBuilder.Entity("PackageReservationTourist", b =>
                {
                    b.Property<Guid>("PackageReservationsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TouristsId")
                        .HasColumnType("char(36)");

                    b.HasKey("PackageReservationsId", "TouristsId");

                    b.HasIndex("TouristsId");

                    b.ToTable("PackageReservationTourist");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Agency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FaxNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Agencies");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.AgencyRelatedHotelDeal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AgencyId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("HotelDealId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("HotelDealId");

                    b.HasIndex("AgencyId", "HotelDealId")
                        .IsUnique();

                    b.ToTable("AgencyRelatedHotelDeals");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Excursion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AgencyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.ToTable("Excursions");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.ExcursionReservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ExcursionId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ExcursionId");

                    b.HasIndex("UserId", "ExcursionId")
                        .IsUnique();

                    b.ToTable("ExcursionReservations");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.HotelDeal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("Id", "HotelId")
                        .IsUnique();

                    b.ToTable("HotelDeals");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.HotelDealReservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AgencyRelatedHotelDealId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("AgencyRelatedHotelDealId", "UserId")
                        .IsUnique();

                    b.ToTable("HotelDealReservations");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Package", b =>
                {
                    b.Property<Guid>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Code");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.PackageReservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AgencyId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.HasIndex("UserId");

                    b.HasIndex("AgencyId", "UserId", "PackageId")
                        .IsUnique();

                    b.ToTable("PackageReservations");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Tourist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tourists");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.ExtendedExcursion", b =>
                {
                    b.HasBaseType("TravelAgency.Domain.Entities.Excursion");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime(6)");

                    b.ToTable("ExtendedExcursions", (string)null);
                });

            modelBuilder.Entity("ExcursionReservationTourist", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.ExcursionReservation", null)
                        .WithMany()
                        .HasForeignKey("ExcursionReservationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Tourist", null)
                        .WithMany()
                        .HasForeignKey("TouristsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExtendedExcursionHotelDeal", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.ExtendedExcursion", null)
                        .WithMany()
                        .HasForeignKey("ExtendedExcursionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.HotelDeal", null)
                        .WithMany()
                        .HasForeignKey("HotelDealsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExtendedExcursionPackage", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.ExtendedExcursion", null)
                        .WithMany()
                        .HasForeignKey("ExtendedExcursionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Package", null)
                        .WithMany()
                        .HasForeignKey("PackagesCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FacilityPackage", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Facility", null)
                        .WithMany()
                        .HasForeignKey("FacilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Package", null)
                        .WithMany()
                        .HasForeignKey("PackagesCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelDealReservationTourist", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.HotelDealReservation", null)
                        .WithMany()
                        .HasForeignKey("HotelDealReservationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Tourist", null)
                        .WithMany()
                        .HasForeignKey("TouristsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PackageReservationTourist", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.PackageReservation", null)
                        .WithMany()
                        .HasForeignKey("PackageReservationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Tourist", null)
                        .WithMany()
                        .HasForeignKey("TouristsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.AgencyRelatedHotelDeal", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Agency", "Agency")
                        .WithMany("AgencyRelatedHotelDeals")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.HotelDeal", "HotelDeal")
                        .WithMany("AgencyRelatedHotelDeals")
                        .HasForeignKey("HotelDealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");

                    b.Navigation("HotelDeal");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Excursion", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Agency", "Agency")
                        .WithMany("Excursions")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.ExcursionReservation", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Excursion", "Excursion")
                        .WithMany("ExcursionReservations")
                        .HasForeignKey("ExcursionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.User", "User")
                        .WithMany("ExcursionReservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excursion");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.HotelDeal", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Deals")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.HotelDealReservation", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.AgencyRelatedHotelDeal", "AgencyRelatedHotelDeal")
                        .WithMany("HotelDealReservations")
                        .HasForeignKey("AgencyRelatedHotelDealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.User", "User")
                        .WithMany("HotelDealReservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgencyRelatedHotelDeal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.PackageReservation", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Agency", "Agency")
                        .WithMany("PackageReservations")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.Package", "Package")
                        .WithMany("PackageReservations")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgency.Domain.Entities.User", "User")
                        .WithMany("PackageReservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");

                    b.Navigation("Package");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.User", b =>
                {
                    b.OwnsOne("TravelAgency.Domain.ValueObjects.Role", "Role", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Permissions")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Role")
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.ExtendedExcursion", b =>
                {
                    b.HasOne("TravelAgency.Domain.Entities.Excursion", null)
                        .WithOne()
                        .HasForeignKey("TravelAgency.Domain.Entities.ExtendedExcursion", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Agency", b =>
                {
                    b.Navigation("AgencyRelatedHotelDeals");

                    b.Navigation("Excursions");

                    b.Navigation("PackageReservations");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.AgencyRelatedHotelDeal", b =>
                {
                    b.Navigation("HotelDealReservations");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Excursion", b =>
                {
                    b.Navigation("ExcursionReservations");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Deals");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.HotelDeal", b =>
                {
                    b.Navigation("AgencyRelatedHotelDeals");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.Package", b =>
                {
                    b.Navigation("PackageReservations");
                });

            modelBuilder.Entity("TravelAgency.Domain.Entities.User", b =>
                {
                    b.Navigation("ExcursionReservations");

                    b.Navigation("HotelDealReservations");

                    b.Navigation("PackageReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
