using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jironimo.DAL.Migrations
{
    public partial class update_password_defaut_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("10baee63-b751-4e4c-b218-c9d6d9df0432"), "Web" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a02dcaba-77e1-4ecd-b209-3386c327c0bd"), "Mobile" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[] { new Guid("d822c802-881b-47e3-8f73-5d8014d3ebe5"), "admin", "heG64OaMXpPxQyzXzwlbOlQHUSEmkz+/n70ZgSRCOolEF8OMg7zrgF8T5SjT/836" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("10baee63-b751-4e4c-b218-c9d6d9df0432"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a02dcaba-77e1-4ecd-b209-3386c327c0bd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d822c802-881b-47e3-8f73-5d8014d3ebe5"));

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
    }
}
