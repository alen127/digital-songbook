using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fingering",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fingering",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fingering",
                value: "[0,0,0,0,0,0]");

            migrationBuilder.UpdateData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fingering",
                value: "[0,0,0,0,0,0]");
        }
    }
}
