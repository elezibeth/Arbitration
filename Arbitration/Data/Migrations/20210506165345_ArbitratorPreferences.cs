using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class ArbitratorPreferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bdeef3-17ce-4a30-9438-a8e7fa1b5cc3");

            migrationBuilder.CreateTable(
                name: "PreferedArbitratorAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTheoryId = table.Column<int>(type: "int", nullable: false),
                    VocationalIndustry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwardsToCompanies = table.Column<int>(type: "int", nullable: false),
                    AwardsToClaimants = table.Column<int>(type: "int", nullable: false),
                    LegalExperience = table.Column<bool>(type: "bit", nullable: false),
                    RelationshipsWithParties = table.Column<bool>(type: "bit", nullable: false),
                    HasStockInCompany = table.Column<bool>(type: "bit", nullable: false),
                    DescriptionOfCOI = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferedArbitratorAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferedArbitratorAttributes_CaseTheories_CaseTheoryId",
                        column: x => x.CaseTheoryId,
                        principalTable: "CaseTheories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5efdc756-bcae-4dde-b2d5-dab01042ef3e", "fb9b138d-61e9-4b3c-a05a-6c771cd74e56", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_PreferedArbitratorAttributes_CaseTheoryId",
                table: "PreferedArbitratorAttributes",
                column: "CaseTheoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreferedArbitratorAttributes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5efdc756-bcae-4dde-b2d5-dab01042ef3e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53bdeef3-17ce-4a30-9438-a8e7fa1b5cc3", "4bb2d93b-b476-4478-bc92-352da39aeb6a", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
