using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDatabase.Migrations
{
    public partial class Initial92 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_VehicleIdentificationNumber",
                table: "Ownerships",
                column: "VehicleIdentificationNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ownerships_VehicleIdentificationNumber",
                table: "Ownerships");
        }
    }
}
