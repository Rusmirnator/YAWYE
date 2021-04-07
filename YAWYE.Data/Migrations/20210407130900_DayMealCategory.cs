using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class DayMealCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayMeal_Days_DayId",
                table: "DayMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_DayMeal_Meals_MealId",
                table: "DayMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_DayMeal_DayMealDayId_DayMealMealId",
                table: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayMeal",
                table: "DayMeal");

            migrationBuilder.RenameTable(
                name: "DayMeal",
                newName: "DayMeals");

            migrationBuilder.RenameIndex(
                name: "IX_DayMeal_MealId",
                table: "DayMeals",
                newName: "IX_DayMeals_MealId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "Days",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "DayMeals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayMeals",
                table: "DayMeals",
                columns: new[] { "DayId", "MealId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DayMeals_Days_DayId",
                table: "DayMeals",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayMeals_Meals_MealId",
                table: "DayMeals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_DayMeals_DayMealDayId_DayMealMealId",
                table: "Days",
                columns: new[] { "DayMealDayId", "DayMealMealId" },
                principalTable: "DayMeals",
                principalColumns: new[] { "DayId", "MealId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayMeals_Days_DayId",
                table: "DayMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_DayMeals_Meals_MealId",
                table: "DayMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_DayMeals_DayMealDayId_DayMealMealId",
                table: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayMeals",
                table: "DayMeals");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "DayMeals");

            migrationBuilder.RenameTable(
                name: "DayMeals",
                newName: "DayMeal");

            migrationBuilder.RenameIndex(
                name: "IX_DayMeals_MealId",
                table: "DayMeal",
                newName: "IX_DayMeal_MealId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "Days",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayMeal",
                table: "DayMeal",
                columns: new[] { "DayId", "MealId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DayMeal_Days_DayId",
                table: "DayMeal",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayMeal_Meals_MealId",
                table: "DayMeal",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_DayMeal_DayMealDayId_DayMealMealId",
                table: "Days",
                columns: new[] { "DayMealDayId", "DayMealMealId" },
                principalTable: "DayMeal",
                principalColumns: new[] { "DayId", "MealId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
