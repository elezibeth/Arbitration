using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c73261e6-4eeb-4b9a-9cb6-5a60b3daf999");

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArbitratorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondArbitratorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a59de089-5677-470c-b4b6-8d6240738227", "20df11be-987d-421e-89aa-454ec4229502", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a59de089-5677-470c-b4b6-8d6240738227");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c73261e6-4eeb-4b9a-9cb6-5a60b3daf999", "938412a3-0589-4292-981b-8f074f145da2", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
