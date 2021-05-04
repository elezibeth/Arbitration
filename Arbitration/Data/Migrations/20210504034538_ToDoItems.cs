using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class ToDoItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebe9a209-324a-48c5-afb7-3e7724cf1555");

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerClaimantId = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlarmDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_ConsumerClaimants_ConsumerClaimantId",
                        column: x => x.ConsumerClaimantId,
                        principalTable: "ConsumerClaimants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19eaa583-0230-4a39-97f5-dbd33ecfb864", "e2d5fdcb-7afd-4ab0-a191-6dc72103ab65", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ConsumerClaimantId",
                table: "ToDoItems",
                column: "ConsumerClaimantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19eaa583-0230-4a39-97f5-dbd33ecfb864");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ebe9a209-324a-48c5-afb7-3e7724cf1555", "c1bc39fa-f642-4816-ac0c-ae7ca81b905c", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
