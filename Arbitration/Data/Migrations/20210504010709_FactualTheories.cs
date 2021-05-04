using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class FactualTheories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4971b42d-9aea-4a25-94d4-e51aa87b426a");

            migrationBuilder.CreateTable(
                name: "FactualTheories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTheoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactualTheories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactualTheories_CaseTheories_CaseTheoryId",
                        column: x => x.CaseTheoryId,
                        principalTable: "CaseTheories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ebe9a209-324a-48c5-afb7-3e7724cf1555", "c1bc39fa-f642-4816-ac0c-ae7ca81b905c", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_FactualTheories_CaseTheoryId",
                table: "FactualTheories",
                column: "CaseTheoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactualTheories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebe9a209-324a-48c5-afb7-3e7724cf1555");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4971b42d-9aea-4a25-94d4-e51aa87b426a", "1e2c394a-8d2d-4736-b29d-3c40be9678f4", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
