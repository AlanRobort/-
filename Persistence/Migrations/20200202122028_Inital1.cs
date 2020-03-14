using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Inital1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "commodities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Commodityname = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CommoditycategoryId = table.Column<int>(nullable: false),
                    startdate = table.Column<string>(nullable: true),
                    days = table.Column<int>(nullable: false),
                    expiredate = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commodities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "commodityCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoryname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commodityCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orderInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Orderstringid = table.Column<string>(nullable: true),
                    Commodityid = table.Column<int>(nullable: false),
                    Startdatetime = table.Column<string>(nullable: true),
                    OrderUser = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "salesrecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoryid = table.Column<int>(nullable: false),
                    Commdityid = table.Column<int>(nullable: false),
                    Userid = table.Column<int>(nullable: false),
                    Startdatetime = table.Column<string>(nullable: true),
                    OrderUser = table.Column<string>(nullable: true),
                    isfinally = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesrecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    socre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrators");

            migrationBuilder.DropTable(
                name: "commodities");

            migrationBuilder.DropTable(
                name: "commodityCategories");

            migrationBuilder.DropTable(
                name: "orderInfos");

            migrationBuilder.DropTable(
                name: "salesrecords");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
