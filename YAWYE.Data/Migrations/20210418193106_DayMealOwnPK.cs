using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class DayMealOwnPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DayMealDayId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DayMealMealId",
                table: "Days");

            migrationBuilder.AddColumn<int>(
                name: "DayMealId",
                table: "Days",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayMealId",
                table: "DayMeals",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayMeals",
                table: "DayMeals",
                column: "DayMealId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_DayMealId",
                table: "Days",
                column: "DayMealId");

            migrationBuilder.CreateIndex(
                name: "IX_DayMeals_DayId",
                table: "DayMeals",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_DayMeals_DayMealId",
                table: "Days",
                column: "DayMealId",
                principalTable: "DayMeals",
                principalColumn: "DayMealId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_DayMeals_DayMealId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_DayMealId",
                table: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayMeals",
                table: "DayMeals");

            migrationBuilder.DropIndex(
                name: "IX_DayMeals_DayId",
                table: "DayMeals");

            migrationBuilder.DropColumn(
                name: "DayMealId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DayMealId",
                table: "DayMeals");

            migrationBuilder.AddColumn<int>(
                name: "DayMealCategory",
                table: "Days",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayMealDayId",
                table: "Days",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayMealMealId",
                table: "Days",
                type: "int",
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
    }
}
