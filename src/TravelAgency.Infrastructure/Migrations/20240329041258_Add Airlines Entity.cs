using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAirlinesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airline",
                table: "PackageReservations");

            migrationBuilder.DropColumn(
                name: "Airline",
                table: "HotelDealReservations");

            migrationBuilder.DropColumn(
                name: "Airline",
                table: "ExcursionReservations");

            migrationBuilder.AddColumn<Guid>(
                name: "AirlineId",
                table: "PackageReservations",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AirlineId",
                table: "HotelDealReservations",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AirlineId",
                table: "ExcursionReservations",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PackageReservations_AirlineId",
                table: "PackageReservations",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelDealReservations_AirlineId",
                table: "HotelDealReservations",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursionReservations_AirlineId",
                table: "ExcursionReservations",
                column: "AirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExcursionReservations_Airlines_AirlineId",
                table: "ExcursionReservations",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelDealReservations_Airlines_AirlineId",
                table: "HotelDealReservations",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageReservations_Airlines_AirlineId",
                table: "PackageReservations",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExcursionReservations_Airlines_AirlineId",
                table: "ExcursionReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelDealReservations_Airlines_AirlineId",
                table: "HotelDealReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageReservations_Airlines_AirlineId",
                table: "PackageReservations");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropIndex(
                name: "IX_PackageReservations_AirlineId",
                table: "PackageReservations");

            migrationBuilder.DropIndex(
                name: "IX_HotelDealReservations_AirlineId",
                table: "HotelDealReservations");

            migrationBuilder.DropIndex(
                name: "IX_ExcursionReservations_AirlineId",
                table: "ExcursionReservations");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "PackageReservations");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "HotelDealReservations");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "ExcursionReservations");

            migrationBuilder.AddColumn<string>(
                name: "Airline",
                table: "PackageReservations",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Airline",
                table: "HotelDealReservations",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Airline",
                table: "ExcursionReservations",
                type: "longtext",
                nullable: false);
        }
    }
}
