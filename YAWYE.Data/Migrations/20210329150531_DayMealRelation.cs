using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class DayMealRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayMealDayId",
                table: "Days",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayMealMealId",
                table: "Days",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DayMeal",
                columns: table => new
                {
                    DayId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayMeal", x => new { x.DayId, x.MealId });
                    table.ForeignKey(
                        name: "FK_DayMeal_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayMeal_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Days_DayMealDayId_DayMealMealId",
                table: "Days",
                columns: new[] { "DayMealDayId", "DayMealMealId" });

            migrationBuilder.CreateIndex(
                name: "IX_DayMeal_MealId",
                table: "DayMeal",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_DayMeal_DayMealDayId_DayMealMealId",
                table: "Days",
                columns: new[] { "DayMealDayId", "DayMealMealId" },
                principalTable: "DayMeal",
                principalColumns: new[] { "DayId", "MealId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_DayMeal_DayMealDayId_DayMealMealId",
                table: "Days");

            migrationBuilder.DropTable(
                name: "DayMeal");

            migrationBuilder.DropIndex(
                name: "IX_Days_DayMealDayId_DayMealMealId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DayMealDayId",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DayMealMealId",
                table: "Days");
        }
    }
}
