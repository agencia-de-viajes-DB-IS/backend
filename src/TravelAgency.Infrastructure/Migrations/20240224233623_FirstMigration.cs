using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false),
                    FaxNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Code);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tourists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Nationality = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourists", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Role_Name = table.Column<string>(type: "longtext", nullable: false),
                    Role_Permissions = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Excursions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Location = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AgencyId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excursions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Excursions_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HotelDeals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HotelId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelDeals_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FacilityPackage",
                columns: table => new
                {
                    FacilitiesId = table.Column<int>(type: "int", nullable: false),
                    PackagesCode = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityPackage", x => new { x.FacilitiesId, x.PackagesCode });
                    table.ForeignKey(
                        name: "FK_FacilityPackage_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityPackage_Packages_PackagesCode",
                        column: x => x.PackagesCode,
                        principalTable: "Packages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PackageReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Airline = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AgencyId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PackageId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageReservations_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageReservations_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageReservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExcursionReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Airline = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ExcursionId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursionReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcursionReservations_Excursions_ExcursionId",
                        column: x => x.ExcursionId,
                        principalTable: "Excursions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcursionReservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExtendedExcursions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedExcursions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtendedExcursions_Excursions_Id",
                        column: x => x.Id,
                        principalTable: "Excursions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AgencyRelatedHotelDeals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AgencyId = table.Column<Guid>(type: "char(36)", nullable: false),
                    HotelDealId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyRelatedHotelDeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyRelatedHotelDeals_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgencyRelatedHotelDeals_HotelDeals_HotelDealId",
                        column: x => x.HotelDealId,
                        principalTable: "HotelDeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PackageReservationTourist",
                columns: table => new
                {
                    PackageReservationsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TouristsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageReservationTourist", x => new { x.PackageReservationsId, x.TouristsId });
                    table.ForeignKey(
                        name: "FK_PackageReservationTourist_PackageReservations_PackageReserva~",
                        column: x => x.PackageReservationsId,
                        principalTable: "PackageReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageReservationTourist_Tourists_TouristsId",
                        column: x => x.TouristsId,
                        principalTable: "Tourists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExcursionReservationTourist",
                columns: table => new
                {
                    ExcursionReservationsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TouristsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursionReservationTourist", x => new { x.ExcursionReservationsId, x.TouristsId });
                    table.ForeignKey(
                        name: "FK_ExcursionReservationTourist_ExcursionReservations_ExcursionR~",
                        column: x => x.ExcursionReservationsId,
                        principalTable: "ExcursionReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcursionReservationTourist_Tourists_TouristsId",
                        column: x => x.TouristsId,
                        principalTable: "Tourists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExtendedExcursionHotelDeal",
                columns: table => new
                {
                    ExtendedExcursionsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    HotelDealsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedExcursionHotelDeal", x => new { x.ExtendedExcursionsId, x.HotelDealsId });
                    table.ForeignKey(
                        name: "FK_ExtendedExcursionHotelDeal_ExtendedExcursions_ExtendedExcurs~",
                        column: x => x.ExtendedExcursionsId,
                        principalTable: "ExtendedExcursions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtendedExcursionHotelDeal_HotelDeals_HotelDealsId",
                        column: x => x.HotelDealsId,
                        principalTable: "HotelDeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExtendedExcursionPackage",
                columns: table => new
                {
                    ExtendedExcursionsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PackagesCode = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtendedExcursionPackage", x => new { x.ExtendedExcursionsId, x.PackagesCode });
                    table.ForeignKey(
                        name: "FK_ExtendedExcursionPackage_ExtendedExcursions_ExtendedExcursio~",
                        column: x => x.ExtendedExcursionsId,
                        principalTable: "ExtendedExcursions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtendedExcursionPackage_Packages_PackagesCode",
                        column: x => x.PackagesCode,
                        principalTable: "Packages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HotelDealReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Airline = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    AgencyRelatedHotelDealId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDealReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelDealReservations_AgencyRelatedHotelDeals_AgencyRelatedH~",
                        column: x => x.AgencyRelatedHotelDealId,
                        principalTable: "AgencyRelatedHotelDeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelDealReservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HotelDealReservationTourist",
                columns: table => new
                {
                    HotelDealReservationsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TouristsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDealReservationTourist", x => new { x.HotelDealReservationsId, x.TouristsId });
                    table.ForeignKey(
                        name: "FK_HotelDealReservationTourist_HotelDealReservations_HotelDealR~",
                        column: x => x.HotelDealReservationsId,
                        principalTable: "HotelDealReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelDealReservationTourist_Tourists_TouristsId",
                        column: x => x.TouristsId,
                        principalTable: "Tourists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyRelatedHotelDeals_AgencyId_HotelDealId",
                table: "AgencyRelatedHotelDeals",
                columns: new[] { "AgencyId", "HotelDealId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgencyRelatedHotelDeals_HotelDealId",
                table: "AgencyRelatedHotelDeals",
                column: "HotelDealId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursionReservations_ExcursionId",
                table: "ExcursionReservations",
                column: "ExcursionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursionReservations_UserId_ExcursionId",
                table: "ExcursionReservations",
                columns: new[] { "UserId", "ExcursionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExcursionReservationTourist_TouristsId",
                table: "ExcursionReservationTourist",
                column: "TouristsId");

            migrationBuilder.CreateIndex(
                name: "IX_Excursions_AgencyId",
                table: "Excursions",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedExcursionHotelDeal_HotelDealsId",
                table: "ExtendedExcursionHotelDeal",
                column: "HotelDealsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedExcursionPackage_PackagesCode",
                table: "ExtendedExcursionPackage",
                column: "PackagesCode");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityPackage_PackagesCode",
                table: "FacilityPackage",
                column: "PackagesCode");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDealReservations_AgencyRelatedHotelDealId_UserId",
                table: "HotelDealReservations",
                columns: new[] { "AgencyRelatedHotelDealId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelDealReservations_UserId",
                table: "HotelDealReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDealReservationTourist_TouristsId",
                table: "HotelDealReservationTourist",
                column: "TouristsId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDeals_HotelId",
                table: "HotelDeals",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDeals_Id_HotelId",
                table: "HotelDeals",
                columns: new[] { "Id", "HotelId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageReservations_AgencyId_UserId_PackageId",
                table: "PackageReservations",
                columns: new[] { "AgencyId", "UserId", "PackageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageReservations_PackageId",
                table: "PackageReservations",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageReservations_UserId",
                table: "PackageReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageReservationTourist_TouristsId",
                table: "PackageReservationTourist",
                column: "TouristsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcursionReservationTourist");

            migrationBuilder.DropTable(
                name: "ExtendedExcursionHotelDeal");

            migrationBuilder.DropTable(
                name: "ExtendedExcursionPackage");

            migrationBuilder.DropTable(
                name: "FacilityPackage");

            migrationBuilder.DropTable(
                name: "HotelDealReservationTourist");

            migrationBuilder.DropTable(
                name: "PackageReservationTourist");

            migrationBuilder.DropTable(
                name: "ExcursionReservations");

            migrationBuilder.DropTable(
                name: "ExtendedExcursions");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "HotelDealReservations");

            migrationBuilder.DropTable(
                name: "PackageReservations");

            migrationBuilder.DropTable(
                name: "Tourists");

            migrationBuilder.DropTable(
                name: "Excursions");

            migrationBuilder.DropTable(
                name: "AgencyRelatedHotelDeals");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "HotelDeals");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
