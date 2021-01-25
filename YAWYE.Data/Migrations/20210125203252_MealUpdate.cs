using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class MealUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Meals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Meals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealId",
                table: "Meals",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Meals_MealId",
                table: "Meals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Meals_MealId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MealId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Meals");
        }
    }
}
