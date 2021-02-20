using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class CalcDataRelationMealId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalcDatas_Products_ProductId",
                table: "CalcDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_CalcDatas_CalcDataId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CalcDatas_CalcDataId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CalcDataId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Meals_CalcDataId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_CalcDatas_ProductId",
                table: "CalcDatas");

            migrationBuilder.DropColumn(
                name: "CalcDataId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CalcDataId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CalcDatas");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "CalcDatas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealIndex",
                table: "CalcDatas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductIndex",
                table: "CalcDatas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CalcDatas_MealId",
                table: "CalcDatas",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalcDatas_Products_MealId",
                table: "CalcDatas",
                column: "MealId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalcDatas_Products_MealId",
                table: "CalcDatas");

            migrationBuilder.DropIndex(
                name: "IX_CalcDatas_MealId",
                table: "CalcDatas");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "CalcDatas");

            migrationBuilder.DropColumn(
                name: "MealIndex",
                table: "CalcDatas");

            migrationBuilder.DropColumn(
                name: "ProductIndex",
                table: "CalcDatas");

            migrationBuilder.AddColumn<int>(
                name: "CalcDataId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalcDataId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CalcDatas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CalcDataId",
                table: "Products",
                column: "CalcDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CalcDataId",
                table: "Meals",
                column: "CalcDataId");

            migrationBuilder.CreateIndex(
                name: "IX_CalcDatas_ProductId",
                table: "CalcDatas",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalcDatas_Products_ProductId",
                table: "CalcDatas",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_CalcDatas_CalcDataId",
                table: "Meals",
                column: "CalcDataId",
                principalTable: "CalcDatas",
                principalColumn: "CalcDataId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CalcDatas_CalcDataId",
                table: "Products",
                column: "CalcDataId",
                principalTable: "CalcDatas",
                principalColumn: "CalcDataId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
