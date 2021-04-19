using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class DayMeal3PK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_DayMeals_DayMealDayId_DayMealMealId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_DayMealDayId_DayMealMealId",
                table: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayMeals",
                table: "DayMeals");

            migrationBuilder.AddColumn<int>(
                name: "DayMealCategory",
                table: "Days",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayMeals",
                table: "DayMeals",
                columns: new[] { "DayId", "MealId", "Category" });

            migrationBuilder.CreateIndex(
                name: "IX_Days_DayMealDayId_DayMealMealId_DayMealCategory",
                table: "Days",
                columns: new[] { "DayMealDayId", "DayMealMealId", "DayMealCategory" });

            migrationBuilder.AddForeignKey(
                name: "FK_Days_DayMeals_DayMealDayId_DayMealMealId_DayMealCategory",
                table: "Days",
                columns: new[] { "DayMealDayId", "DayMealMealId", "DayMealCategory" },
                principalTable: "DayMeals",
                principalColumns: new[] { "DayId", "MealId", "Category" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_DayMeals_DayMealDayId_DayMealMealId_DayMealCategory",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_DayMealDayId_DayMealMealId_DayMealCategory",
                table: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayMeals",
                table: "DayMeals");

            migrationBuilder.DropColumn(
                name: "DayMealCategory",
                table: "Days");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayMeals",
                table: "DayMeals",
                columns: new[] { "DayId", "MealId" });

            migrationBuilder.CreateIndex(
                name: "IX_Days_DayMealDayId_DayMealMealId",
                table: "Days",
                columns: new[] { "DayMealDayId", "DayMealMealId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Days_DayMeals_DayMealDayId_DayMealMealId",
                table: "Days",
                columns: new[] { "DayMealDayId", "DayMealMealId" },
                principalTable: "DayMeals",
                principalColumns: new[] { "DayId", "MealId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
