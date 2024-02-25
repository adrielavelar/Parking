using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parking.Data.Migrations
{
    /// <inheritdoc />
    public partial class configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VacancyConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MotorcycleVacancies = table.Column<int>(type: "int", nullable: false),
                    LargeVacancies = table.Column<int>(type: "int", nullable: false),
                    NormalVacancies = table.Column<int>(type: "int", nullable: false),
                    TotalVacancies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyConfigurations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacancyConfigurations");
        }
    }
}
