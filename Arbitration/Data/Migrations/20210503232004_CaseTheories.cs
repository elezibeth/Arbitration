using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class CaseTheories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e0061c1-b123-4383-9d0b-5b76cda4b22f");

            migrationBuilder.CreateTable(
                name: "CaseTheories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerClaimantId = table.Column<int>(type: "int", nullable: false),
                    LawBroken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowLawBroken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perpetrator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProofOfIntent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InInitiation = table.Column<bool>(type: "bit", nullable: false),
                    InArbitratorInvitation = table.Column<bool>(type: "bit", nullable: false),
                    InArbitratiorAppointment = table.Column<bool>(type: "bit", nullable: false),
                    InPreliminaryHearing = table.Column<bool>(type: "bit", nullable: false),
                    InAward = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTheories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseTheories_ConsumerClaimants_ConsumerClaimantId",
                        column: x => x.ConsumerClaimantId,
                        principalTable: "ConsumerClaimants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa339ca8-084d-4627-ae32-9703bd44b999", "b3e48281-9ac4-4ea2-85cc-bcdb3c8d9b2f", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_CaseTheories_ConsumerClaimantId",
                table: "CaseTheories",
                column: "ConsumerClaimantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseTheories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa339ca8-084d-4627-ae32-9703bd44b999");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e0061c1-b123-4383-9d0b-5b76cda4b22f", "9b2bc0e5-7a9e-4c26-a64a-146594441839", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
