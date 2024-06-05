using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedArtistAndChordData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "ImageUrl", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "https://upload.wikimedia.org/wikipedia/commons/d/d8/The_Beatles_members_at_New_York_City_in_1964.jpg", "The Beatles", "cfa41478-4272-4ec9-a3bc-664ceb508dd1" },
                    { 2, "https://upload.wikimedia.org/wikipedia/commons/0/02/Eric_Burdon_%26_the_Animals.jpg", "The Animals", "cfa41478-4272-4ec9-a3bc-664ceb508dd1" }
                });

            migrationBuilder.InsertData(
                table: "Chords",
                columns: new[] { "Id", "Fingering", "Name", "Strings", "UserId" },
                values: new object[,]
                {
                    { 1, "[0,0,0,0,0,0]", "E", "[0,2,2,1,0,0]", "cfa41478-4272-4ec9-a3bc-664ceb508dd1" },
                    { 2, "[0,0,0,0,0,0]", "D", "[-1,-1,0,2,3,2]", "cfa41478-4272-4ec9-a3bc-664ceb508dd1" },
                    { 3, "[-1,-1,1,2,3,-1]", "A", "[-1,0,2,2,2,0]", "cfa41478-4272-4ec9-a3bc-664ceb508dd1" },
                    { 4, "[1,3,1,2,1,1]", "E7", "[12,14,12,13,12,12]", "cfa41478-4272-4ec9-a3bc-664ceb508dd1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
