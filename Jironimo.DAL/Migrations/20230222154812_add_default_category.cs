using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jironimo.DAL.Migrations
{
    public partial class add_default_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c2b23810-36c0-46fc-aefb-83c5c937b8ec"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("37f8a2a5-2db6-4f78-af65-b52fd41fa11e"), "Mobile" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d4e968f5-7a79-4870-bf22-48771fec1d7c"), "Web" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[] { new Guid("85d38113-dfa8-4f42-a6da-829a7e0fadd6"), "admin", "Frostiq1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("37f8a2a5-2db6-4f78-af65-b52fd41fa11e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4e968f5-7a79-4870-bf22-48771fec1d7c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("85d38113-dfa8-4f42-a6da-829a7e0fadd6"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[] { new Guid("c2b23810-36c0-46fc-aefb-83c5c937b8ec"), "admin", "Frostiq1" });
        }
    }
}
