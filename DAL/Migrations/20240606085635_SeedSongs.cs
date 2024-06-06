using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ArtistId", "Bpm", "Name", "StrummingPattern", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, "Oh Darling!", null, "cfa41478-4272-4ec9-a3bc-664ceb508dd1" },
                    { 2, 2, null, "House of the Rising Sun", null, "cfa41478-4272-4ec9-a3bc-664ceb508dd1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
