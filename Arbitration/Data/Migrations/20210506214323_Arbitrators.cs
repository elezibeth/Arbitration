using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class Arbitrators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5efdc756-bcae-4dde-b2d5-dab01042ef3e");

            migrationBuilder.CreateTable(
                name: "Arbitratorss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTheoryId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Arbitratorss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arbitratorss_CaseTheories_CaseTheoryId",
                        column: x => x.CaseTheoryId,
                        principalTable: "CaseTheories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c73261e6-4eeb-4b9a-9cb6-5a60b3daf999", "938412a3-0589-4292-981b-8f074f145da2", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_Arbitratorss_CaseTheoryId",
                table: "Arbitratorss",
                column: "CaseTheoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbitratorss");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c73261e6-4eeb-4b9a-9cb6-5a60b3daf999");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5efdc756-bcae-4dde-b2d5-dab01042ef3e", "fb9b138d-61e9-4b3c-a05a-6c771cd74e56", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
