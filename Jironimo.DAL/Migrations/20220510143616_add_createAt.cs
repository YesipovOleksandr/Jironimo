using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jironimo.DAL.Migrations
{
    public partial class add_createAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Applications",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Applications");
        }
    }
}
