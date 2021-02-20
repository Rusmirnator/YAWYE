using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class CDdbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalcDataId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalcDataId",
                table: "Meals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CalcDatas",
                columns: table => new
                {
                    CalcDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientWeight = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcDatas", x => x.CalcDataId);
                    table.ForeignKey(
                        name: "FK_CalcDatas_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_CalcDatas_CalcDataId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CalcDatas_CalcDataId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CalcDatas");

            migrationBuilder.DropIndex(
                name: "IX_Products_CalcDataId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Meals_CalcDataId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "CalcDataId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CalcDataId",
                table: "Meals");
        }
    }
}
