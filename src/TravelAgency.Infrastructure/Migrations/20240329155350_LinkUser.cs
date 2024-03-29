using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LinkUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Excursions",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Excursions",
                type: "longtext",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "TouristUser",
                columns: table => new
                {
                    TouristsId = table.Column<string>(type: "varchar(255)", nullable: false),
                    UsersId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristUser", x => new { x.TouristsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TouristUser_Tourists_TouristsId",
                        column: x => x.TouristsId,
                        principalTable: "Tourists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TouristUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TouristUser_UsersId",
                table: "TouristUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristUser");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Excursions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Excursions");
        }
    }
}
