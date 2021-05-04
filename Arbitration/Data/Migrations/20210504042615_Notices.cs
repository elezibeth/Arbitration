using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class Notices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19eaa583-0230-4a39-97f5-dbd33ecfb864");

            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerClaimantId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Notices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notices_ConsumerClaimants_ConsumerClaimantId",
                        column: x => x.ConsumerClaimantId,
                        principalTable: "ConsumerClaimants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f23e76b-84ae-43b3-bb06-6e1863444581", "d3a58331-3055-4331-a95b-f801564c682a", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_Notices_ConsumerClaimantId",
                table: "Notices",
                column: "ConsumerClaimantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f23e76b-84ae-43b3-bb06-6e1863444581");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19eaa583-0230-4a39-97f5-dbd33ecfb864", "e2d5fdcb-7afd-4ab0-a191-6dc72103ab65", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
