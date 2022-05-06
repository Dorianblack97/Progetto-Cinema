using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgettoCinema.WebClient.Migrations
{
    public partial class fixTicketsToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_PersonId",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PersonId",
                table: "Tickets",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_PersonId",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PersonId",
                table: "Tickets",
                column: "PersonId",
                unique: true);
        }
    }
}
