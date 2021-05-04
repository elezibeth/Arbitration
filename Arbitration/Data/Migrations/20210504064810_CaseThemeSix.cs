using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class CaseThemeSix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "951fcdc3-55f3-4f6b-8f97-d7a970f6b668");

            migrationBuilder.CreateTable(
                name: "AnticipatedAffirmativeDefenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTheoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neutralization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnticipatedAffirmativeDefenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnticipatedAffirmativeDefenses_CaseTheories_CaseTheoryId",
                        column: x => x.CaseTheoryId,
                        principalTable: "CaseTheories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arbitrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTheoryId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    VocationalIndustry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwardsToCompanies = table.Column<int>(type: "int", nullable: false),
                    AwardsToClaimants = table.Column<int>(type: "int", nullable: false),
                    LegalExperience = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    RelationshipsWithParties = table.Column<bool>(type: "bit", nullable: false),
                    HasStockInCompany = table.Column<bool>(type: "bit", nullable: false),
                    DescriptionOfCOI = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arbitrators_CaseTheories_CaseTheoryId",
                        column: x => x.CaseTheoryId,
                        principalTable: "CaseTheories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTheoryId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralNotes_CaseTheories_CaseTheoryId",
                        column: x => x.CaseTheoryId,
                        principalTable: "CaseTheories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartiesInvolved",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartiesInvolved", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheoryEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactualTheoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoryEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheoryEvents_FactualTheories_FactualTheoryId",
                        column: x => x.FactualTheoryId,
                        principalTable: "FactualTheories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53bdeef3-17ce-4a30-9438-a8e7fa1b5cc3", "4bb2d93b-b476-4478-bc92-352da39aeb6a", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_AnticipatedAffirmativeDefenses_CaseTheoryId",
                table: "AnticipatedAffirmativeDefenses",
                column: "CaseTheoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Arbitrators_CaseTheoryId",
                table: "Arbitrators",
                column: "CaseTheoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralNotes_CaseTheoryId",
                table: "GeneralNotes",
                column: "CaseTheoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TheoryEvents_FactualTheoryId",
                table: "TheoryEvents",
                column: "FactualTheoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnticipatedAffirmativeDefenses");

            migrationBuilder.DropTable(
                name: "Arbitrators");

            migrationBuilder.DropTable(
                name: "GeneralNotes");

            migrationBuilder.DropTable(
                name: "PartiesInvolved");

            migrationBuilder.DropTable(
                name: "TheoryEvents");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bdeef3-17ce-4a30-9438-a8e7fa1b5cc3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "951fcdc3-55f3-4f6b-8f97-d7a970f6b668", "32300ddf-e37a-48fa-af19-3b3e2632bbfc", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
