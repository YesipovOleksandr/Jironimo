using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jironimo.DAL.Migrations
{
    public partial class add_ApplicationDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "ApplicationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePathTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionImage = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationDetails_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDeveloper",
                columns: table => new
                {
                    ApplicationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DevelopersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDeveloper", x => new { x.ApplicationsId, x.DevelopersId });
                    table.ForeignKey(
                        name: "FK_ApplicationDeveloper_Applications_ApplicationsId",
                        column: x => x.ApplicationsId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationDeveloper_Developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_ApplicationId",
                table: "ApplicationDetails",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDeveloper_DevelopersId",
                table: "ApplicationDeveloper",
                column: "DevelopersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationDetails");

            migrationBuilder.DropTable(
                name: "ApplicationDeveloper");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");
        }
    }
}
