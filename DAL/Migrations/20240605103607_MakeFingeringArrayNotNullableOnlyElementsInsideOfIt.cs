using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class MakeFingeringArrayNotNullableOnlyElementsInsideOfIt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fingering",
                table: "Chords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fingering",
                table: "Chords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
