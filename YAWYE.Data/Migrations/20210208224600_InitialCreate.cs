using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Kcal = table.Column<double>(nullable: false),
                    Protein = table.Column<double>(nullable: false),
                    Carbohydrates = table.Column<double>(nullable: false),
                    Fat = table.Column<double>(nullable: false),
                    Fiber = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    ImgPath = table.Column<string>(nullable: true),
                    MealId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meals_Meals_MealId1",
                        column: x => x.MealId1,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<double>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Make = table.Column<string>(maxLength: 30, nullable: false),
                    Kcal = table.Column<double>(nullable: false),
                    Protein = table.Column<double>(nullable: false),
                    Carbohydrates = table.Column<double>(nullable: false),
                    Fat = table.Column<double>(nullable: false),
                    Fiber = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    BarCode = table.Column<int>(nullable: false),
                    ImgPath = table.Column<string>(nullable: true),
                    HasImage = table.Column<bool>(nullable: false),
                    MealId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealId1",
                table: "Meals",
                column: "MealId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MealId",
                table: "Products",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
