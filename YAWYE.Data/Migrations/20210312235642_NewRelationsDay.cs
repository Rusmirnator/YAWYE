using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class NewRelationsDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Days_DayId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "TodayIs",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "Meals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Days",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Days",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Days_MealId",
                table: "Days",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Meals_MealId",
                table: "Days",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Days_DayId",
                table: "Meals",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Meals_MealId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Days_DayId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Days_MealId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "DayId",
                table: "Meals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TodayIs",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Days_DayId",
                table: "Meals",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
