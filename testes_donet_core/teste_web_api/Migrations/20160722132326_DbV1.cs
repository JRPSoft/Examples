using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace teste_web_api.Migrations
{
    public partial class DbV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    BusinessValue = table.Column<string>(nullable: true),
                    OtherBussinessValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
