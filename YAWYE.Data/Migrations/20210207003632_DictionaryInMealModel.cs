using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class DictionaryInMealModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Meals_MealId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MealId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MealId",
                table: "Products",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Meals_MealId",
                table: "Products",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
