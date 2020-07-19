using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalAplicada1.Migrations
{
    public partial class migracionNumero3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombreusuario",
                table: "UsuarioDetalle",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombreusuario",
                table: "UsuarioDetalle");
        }
    }
}
