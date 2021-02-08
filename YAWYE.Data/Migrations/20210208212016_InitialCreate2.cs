using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Meals_MealId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Meals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_ProductId",
                table: "Meals",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Products_ProductId",
                table: "Meals",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Meals_MealId",
                table: "Products",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Products_ProductId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Meals_MealId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Meals_ProductId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Meals_MealId",
                table: "Products",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
