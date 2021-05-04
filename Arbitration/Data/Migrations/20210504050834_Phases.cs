using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class Phases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f23e76b-84ae-43b3-bb06-6e1863444581");

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerClaimantId = table.Column<int>(type: "int", nullable: false),
                    NotificationOfFiling = table.Column<bool>(type: "bit", nullable: false),
                    NoticeOfArbitratorSelection = table.Column<bool>(type: "bit", nullable: false),
                    ArbitratorsDisclosures = table.Column<bool>(type: "bit", nullable: false),
                    SignedOathDocument = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentOfArbitrator = table.Column<bool>(type: "bit", nullable: false),
                    Schedule = table.Column<bool>(type: "bit", nullable: false),
                    SchedulingOrder = table.Column<bool>(type: "bit", nullable: false),
                    CompletionOfHearing = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phases_ConsumerClaimants_ConsumerClaimantId",
                        column: x => x.ConsumerClaimantId,
                        principalTable: "ConsumerClaimants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "951fcdc3-55f3-4f6b-8f97-d7a970f6b668", "32300ddf-e37a-48fa-af19-3b3e2632bbfc", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_Phases_ConsumerClaimantId",
                table: "Phases",
                column: "ConsumerClaimantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "951fcdc3-55f3-4f6b-8f97-d7a970f6b668");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f23e76b-84ae-43b3-bb06-6e1863444581", "d3a58331-3055-4331-a95b-f801564c682a", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
