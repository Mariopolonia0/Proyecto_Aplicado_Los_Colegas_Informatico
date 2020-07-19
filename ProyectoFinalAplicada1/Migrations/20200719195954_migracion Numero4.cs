using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalAplicada1.Migrations
{
    public partial class migracionNumero4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombreusuario",
                table: "UsuarioDetalle",
                newName: "NombreUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreUsuario",
                table: "UsuarioDetalle",
                newName: "Nombreusuario");
        }
    }
}
