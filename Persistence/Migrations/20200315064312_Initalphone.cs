using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initalphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "days",
                table: "commodities");

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "commodities",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "administrators",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone",
                table: "commodities");

            migrationBuilder.AddColumn<int>(
                name: "days",
                table: "commodities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "administrators",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
