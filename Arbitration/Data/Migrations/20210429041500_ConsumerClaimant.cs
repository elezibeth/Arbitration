using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbitration.Data.Migrations
{
    public partial class ConsumerClaimant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9433d839-9068-4a7e-a7fa-ead72338b0c1");

            migrationBuilder.CreateTable(
                name: "ConsumerClaimants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InArbitration = table.Column<bool>(type: "bit", nullable: false),
                    CompanyDisputing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArbitrationLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerClaimants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerClaimants_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e0061c1-b123-4383-9d0b-5b76cda4b22f", "9b2bc0e5-7a9e-4c26-a64a-146594441839", "CommercialClaimant", "COMMERCIALCLAIMANT" });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerClaimants_IdentityUserId",
                table: "ConsumerClaimants",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerClaimants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e0061c1-b123-4383-9d0b-5b76cda4b22f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9433d839-9068-4a7e-a7fa-ead72338b0c1", "d535c850-2196-4f89-a691-c180e53e43f2", "CommercialClaimant", "COMMERCIALCLAIMANT" });
        }
    }
}
