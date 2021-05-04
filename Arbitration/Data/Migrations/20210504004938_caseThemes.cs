using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class caseThemes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa339ca8-084d-4627-ae32-9703bd44b999");

            migrationBuilder.CreateTable(
                name: "CaseThemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTheoryId = table.Column<int>(type: "int", nullable: false),
                    ArbiterChair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreTruth = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseThemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseThemes_CaseTheories_CaseTheoryId",
                        column: x => x.CaseTheoryId,
                        principalTable: "CaseTheories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4971b42d-9aea-4a25-94d4-e51aa87b426a", "1e2c394a-8d2d-4736-b29d-3c40be9678f4", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_CaseThemes_CaseTheoryId",
                table: "CaseThemes",
                column: "CaseTheoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseThemes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4971b42d-9aea-4a25-94d4-e51aa87b426a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa339ca8-084d-4627-ae32-9703bd44b999", "b3e48281-9ac4-4ea2-85cc-bcdb3c8d9b2f", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
