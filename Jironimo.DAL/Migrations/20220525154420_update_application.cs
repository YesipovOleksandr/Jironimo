using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jironimo.DAL.Migrations
{
    public partial class update_application : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDetails_Applications_ApplicationId",
                table: "ApplicationDetails");

            migrationBuilder.DropColumn(
                name: "PositionRight",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "AppStoreLink",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GooglePlayLink",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDetails_Applications_ApplicationId",
                table: "ApplicationDetails",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDetails_Applications_ApplicationId",
                table: "ApplicationDetails");

            migrationBuilder.DropColumn(
                name: "AppStoreLink",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "GooglePlayLink",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Applications");

            migrationBuilder.AddColumn<bool>(
                name: "PositionRight",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDetails_Applications_ApplicationId",
                table: "ApplicationDetails",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");
        }
    }
}
