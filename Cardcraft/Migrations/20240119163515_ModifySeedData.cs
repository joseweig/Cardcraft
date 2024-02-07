using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cardcraft.Migrations
{
    /// <inheritdoc />
    public partial class ModifySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Attack", "Health" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "Health" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Attack", "Health" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attack", "Health" },
                values: new object[] { 3, 2 });
        }
    }
}
