using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiScratch.Migrations
{
    public partial class AddCommentOnPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "PointsTable",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "PointsTable");
        }
    }
}
