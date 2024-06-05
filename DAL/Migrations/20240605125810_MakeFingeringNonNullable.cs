using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class MakeFingeringNonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fingering",
                value: "[-1,-1,-1,-1,-1,-1]");

            migrationBuilder.UpdateData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fingering",
                value: "[-1,-1,-1,-1,-1,-1]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fingering",
                value: "[null,null,null,null,null,null]");

            migrationBuilder.UpdateData(
                table: "Chords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fingering",
                value: "[null,null,null,null,null,null]");
        }
    }
}
