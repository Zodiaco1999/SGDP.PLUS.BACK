using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEG.MENU.Migrations
{
    /// <inheritdoc />
    public partial class m2805 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModificaUsuario",
                schema: "menu",
                table: "Aplicacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModificaMaquina",
                schema: "menu",
                table: "Aplicacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreaUsuario",
                schema: "menu",
                table: "Aplicacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreaMaquina",
                schema: "menu",
                table: "Aplicacion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Modulo",
                schema: "menu",
                columns: table => new
                {
                    AplicacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreModulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescModulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IconoPrefijo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreaUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreaFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreaMaquina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModificaUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModificaFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificaMaquina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => new { x.AplicacionId, x.ModuloId });
                    table.ForeignKey(
                        name: "FK_Modulo_Aplication",
                        column: x => x.AplicacionId,
                        principalSchema: "menu",
                        principalTable: "Aplicacion",
                        principalColumn: "AplicacionId");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modulo",
                schema: "menu");

            migrationBuilder.AlterColumn<string>(
                name: "ModificaUsuario",
                schema: "menu",
                table: "Aplicacion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ModificaMaquina",
                schema: "menu",
                table: "Aplicacion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreaUsuario",
                schema: "menu",
                table: "Aplicacion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreaMaquina",
                schema: "menu",
                table: "Aplicacion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
