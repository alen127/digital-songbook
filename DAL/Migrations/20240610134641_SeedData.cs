using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "ImageUrl", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "https://upload.wikimedia.org/wikipedia/commons/d/d8/The_Beatles_members_at_New_York_City_in_1964.jpg", "The Beatles", "39ffa927-8fd6-46a4-88ad-b8347c07adaa" },
                    { 2, "https://upload.wikimedia.org/wikipedia/commons/0/02/Eric_Burdon_%26_the_Animals.jpg", "The Animals", "39ffa927-8fd6-46a4-88ad-b8347c07adaa" }
                });

            migrationBuilder.InsertData(
                table: "Chords",
                columns: new[] { "Id", "Fingers", "Frets", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "[-1,-1,-1,-1,-1,-1]", "[0,2,2,1,0,0]", "E", "39ffa927-8fd6-46a4-88ad-b8347c07adaa" },
                    { 2, "[-1,-1,-1,-1,-1,-1]", "[-1,-1,0,2,3,2]", "D", "39ffa927-8fd6-46a4-88ad-b8347c07adaa" },
                    { 3, "[-1,-1,1,2,3,-1]", "[-1,0,2,2,2,0]", "A", "39ffa927-8fd6-46a4-88ad-b8347c07adaa" },
                    { 4, "[1,3,1,2,1,1]", "[12,14,12,13,12,12]", "E7", "39ffa927-8fd6-46a4-88ad-b8347c07adaa" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ApplicationUserId", "ArtistId", "Bpm", "Name", "StrummingPattern", "UserId" },
                values: new object[,]
                {
                    { 1, null, 1, 72, "Let it be", "[true,false,false,false,false,false,false,false,true,false,false,false,false,false,false,false]", "39ffa927-8fd6-46a4-88ad-b8347c07adaa" },
                    { 2, null, 2, null, "House of the Rising Sun", "[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]", "39ffa927-8fd6-46a4-88ad-b8347c07adaa" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Lyrics", "Name", "Position", "SongId", "StrummingPattern" },
                values: new object[,]
                {
                    { 1, "When I find myself in times of trouble, Mother Mary comes to me\nSpeaking words of wisdom, let it be\nAnd in my hour of darkness she is standing right in front of me\nSpeaking words of wisdom, let it be", "Verse 1", 1, 1, "[true,false,false,false,true,false,true,false,true,false,false,false,true,false,true,false]" },
                    { 2, "Let it be, let it be, let it be, let it be\nWhisper words of wisdom, let it be", "Chorus", 2, 1, "[true,false,false,false,true,false,true,false,true,true,false,false,true,false,true,false]" },
                    { 3, "And when the broken hearted people living in the world agree\nThere will be an answer, let it be\nFor though they may be parted, there is still a chance that they will see\nThere will be an answer, let it be", "Verse 2", 3, 1, "[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]" }
                });

            migrationBuilder.InsertData(
                table: "ChordSongSection",
                columns: new[] { "Id", "ChordId", "SongSectionId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 4, 1 },
                    { 4, 2, 1 },
                    { 5, 1, 1 },
                    { 6, 3, 1 },
                    { 7, 1, 2 },
                    { 8, 3, 2 },
                    { 9, 3, 2 },
                    { 10, 2, 3 },
                    { 11, 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ChordSongSection",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
