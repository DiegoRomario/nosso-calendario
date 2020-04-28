using Microsoft.EntityFrameworkCore.Migrations;

namespace NossoCalendario.Data.Migrations
{
    public partial class AlterTableUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "VARCHAR(240)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(240)");
        }
    }
}
