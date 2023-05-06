using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addnatification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Natifications",
                columns: table => new
                {
                    NatificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NatificationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatificationTypeSembol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatificationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatificationStatus = table.Column<bool>(type: "bit", nullable: false),
                    NatificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natifications", x => x.NatificationID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Natifications");
        }
    }
}
