using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDatabase.Migrations
{
    public partial class Initial66 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ownerships_PersonId",
                table: "Ownerships");

            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_PersonId",
                table: "Ownerships",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ownerships_PersonId",
                table: "Ownerships");

            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_PersonId",
                table: "Ownerships",
                column: "PersonId",
                unique: true);
        }
    }
}
