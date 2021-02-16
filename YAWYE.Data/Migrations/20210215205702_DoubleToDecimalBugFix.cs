using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class DoubleToDecimalBugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BarCode",
                table: "Products",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BarCode",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
