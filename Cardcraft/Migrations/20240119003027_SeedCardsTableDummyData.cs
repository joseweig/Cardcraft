using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cardcraft.Migrations
{
    /// <inheritdoc />
    public partial class SeedCardsTableDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Description", "Family", "Health", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, "An unemployed programmer.", 0, 1, "Mayo" },
                    { 2, 3, 0, "A tiny berserker chihuahua.", 3, 2, "Bolo" },
                    { 3, 2, 0, "An tall exotic voluptuous woman.", 0, 3, "Cami" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
