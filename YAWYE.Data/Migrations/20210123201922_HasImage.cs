using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class HasImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasImage",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Carbohydrates",
                table: "Meals",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "Meals",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fiber",
                table: "Meals",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Kcal",
                table: "Meals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Meals",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Meals",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "Meals",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Meals",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasImage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Carbohydrates",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Fiber",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Kcal",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Meals");
        }
    }
}
