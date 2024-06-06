using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStrummingPatternToBooleanArray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "StrummingPattern",
                value: "[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                column: "StrummingPattern",
                value: "[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "StrummingPattern",
                value: "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                column: "StrummingPattern",
                value: "[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]");
        }
    }
}
