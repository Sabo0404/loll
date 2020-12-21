using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTimeOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Smile = table.Column<int>(type: "INTEGER", nullable: false),
                    Beauty = table.Column<int>(type: "INTEGER", nullable: false),
                    Nature = table.Column<int>(type: "INTEGER", nullable: false),
                    Character = table.Column<int>(type: "INTEGER", nullable: false),
                    Communication = table.Column<int>(type: "INTEGER", nullable: false),
                    Humor = table.Column<int>(type: "INTEGER", nullable: false),
                    OfPersonId = table.Column<long>(type: "INTEGER", nullable: false),
                    ByPersonId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citizenships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<long>(type: "INTEGER", nullable: false),
                    CityId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizenships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citizenships_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citizenships_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FriendEntrys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstPersonId = table.Column<long>(type: "INTEGER", nullable: false),
                    SecondPersonId = table.Column<long>(type: "INTEGER", nullable: false),
                    PersonId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendEntrys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendEntrys_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citizenships_CityId",
                table: "Citizenships",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizenships_PersonId",
                table: "Citizenships",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendEntrys_PersonId",
                table: "FriendEntrys",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citizenships");

            migrationBuilder.DropTable(
                name: "FriendEntrys");

            migrationBuilder.DropTable(
                name: "Qualities");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
