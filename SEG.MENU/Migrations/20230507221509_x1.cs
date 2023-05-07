using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEG.MENU.Migrations
{
    /// <inheritdoc />
    public partial class x1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "menu");

            migrationBuilder.CreateTable(
                name: "Aplicacion",
                schema: "menu",
                columns: table => new
                {
                    AplicacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreAplicacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescAplicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreaUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreaFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreaMaquina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificaUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificaFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificaMaquina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacion", x => x.AplicacionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacion_AplicacionId",
                schema: "menu",
                table: "Aplicacion",
                column: "AplicacionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacion",
                schema: "menu");
        }
    }
}
