using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalAplicada1.Migrations
{
    public partial class Migracion_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioDetalle",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDetalle", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_UsuarioDetalle_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioDetalle");
        }
    }
}
