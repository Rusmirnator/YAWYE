using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class MealOwner2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Meals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Meals");
        }
    }
}
