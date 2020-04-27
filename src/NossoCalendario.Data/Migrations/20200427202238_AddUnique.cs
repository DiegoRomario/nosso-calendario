using Microsoft.EntityFrameworkCore.Migrations;

namespace NossoCalendario.Data.Migrations
{
    public partial class AddUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Usuario_Email",
                table: "Usuario",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Usuario_Email",
                table: "Usuario");
        }
    }
}
