using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class NoCalcData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalcDatas");

            migrationBuilder.AddColumn<int>(
                name: "MealProductMealId",
                table: "MealProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealProductProductId",
                table: "MealProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealProducts_MealProductMealId_MealProductProductId",
                table: "MealProducts",
                columns: new[] { "MealProductMealId", "MealProductProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MealProducts_MealProducts_MealProductMealId_MealProductProductId",
                table: "MealProducts",
                columns: new[] { "MealProductMealId", "MealProductProductId" },
                principalTable: "MealProducts",
                principalColumns: new[] { "MealId", "ProductId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealProducts_MealProducts_MealProductMealId_MealProductProductId",
                table: "MealProducts");

            migrationBuilder.DropIndex(
                name: "IX_MealProducts_MealProductMealId_MealProductProductId",
                table: "MealProducts");

            migrationBuilder.DropColumn(
                name: "MealProductMealId",
                table: "MealProducts");

            migrationBuilder.DropColumn(
                name: "MealProductProductId",
                table: "MealProducts");

            migrationBuilder.CreateTable(
                name: "CalcDatas",
                columns: table => new
                {
                    CalcDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: true),
                    MealIndex = table.Column<int>(type: "int", nullable: false),
                    ProductIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcDatas", x => x.CalcDataId);
                    table.ForeignKey(
                        name: "FK_CalcDatas_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalcDatas_MealId",
                table: "CalcDatas",
                column: "MealId");
        }
    }
}
