using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VSDocker.EFCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "VSDocker");

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "VSDocker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsAcvite = table.Column<bool>(nullable: false),
                    IsSoftDelete = table.Column<bool>(nullable: false, defaultValue: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company",
                schema: "VSDocker");
        }
    }
}
