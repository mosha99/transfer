using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Receiver.Migrations
{
    public partial class vol1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Family = table.Column<string>(type: "TEXT", nullable: false),
                    Mobile = table.Column<string>(type: "TEXT", nullable: false),
                    Mail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "transferrEdntities",
                columns: table => new
                {
                    TransferrEdntitiesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityGuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    LocalId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    TransferrDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transferrEdntities", x => x.TransferrEdntitiesId);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_admins_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdminId = table.Column<int>(type: "INTEGER", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_users_admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_admins_dateTime",
                table: "admins",
                column: "dateTime");

            migrationBuilder.CreateIndex(
                name: "IX_admins_PersonId",
                table: "admins",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_people_dateTime",
                table: "people",
                column: "dateTime");

            migrationBuilder.CreateIndex(
                name: "IX_transferrEdntities_EntityGuid",
                table: "transferrEdntities",
                column: "EntityGuid");

            migrationBuilder.CreateIndex(
                name: "IX_users_AdminId",
                table: "users",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_users_dateTime",
                table: "users",
                column: "dateTime");

            migrationBuilder.CreateIndex(
                name: "IX_users_PersonId",
                table: "users",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transferrEdntities");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
