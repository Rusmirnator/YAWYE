using Microsoft.EntityFrameworkCore.Migrations;

namespace YAWYE.Data.Migrations
{
    public partial class NewRelationsDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TodayIs",
                table: "Days");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Days",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Days");

            migrationBuilder.AddColumn<int>(
                name: "TodayIs",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
