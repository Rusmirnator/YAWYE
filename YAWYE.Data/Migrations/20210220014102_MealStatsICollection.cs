using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class MealStatsICollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId1",
                table: "CalcDatas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalcDatas_MealId1",
                table: "CalcDatas",
                column: "MealId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CalcDatas_Meals_MealId1",
                table: "CalcDatas",
                column: "MealId1",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalcDatas_Meals_MealId1",
                table: "CalcDatas");

            migrationBuilder.DropIndex(
                name: "IX_CalcDatas_MealId1",
                table: "CalcDatas");

            migrationBuilder.DropColumn(
                name: "MealId1",
                table: "CalcDatas");
        }
    }
}
