using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiScratch.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CityTable",
                columns: new[] { "Id", "Detail", "Name" },
                values: new object[] { 1, "Busy City especially during rush hours.", "Nairobi" });

            migrationBuilder.InsertData(
                table: "CityTable",
                columns: new[] { "Id", "Detail", "Name" },
                values: new object[] { 2, "Has a big park within the city center", "New York" });

            migrationBuilder.InsertData(
                table: "PointsTable",
                columns: new[] { "Id", "CityId", "Comment", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Very enjoyable place", "Maasai Mara" },
                    { 2, 1, "A bit too serious", "Bomas of Kenya" },
                    { 3, 2, "Ohh! Politicos!", "Nation Assembly" },
                    { 4, 2, "Dinosaures leave here.", "Oama park" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointsTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CityTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CityTable",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
