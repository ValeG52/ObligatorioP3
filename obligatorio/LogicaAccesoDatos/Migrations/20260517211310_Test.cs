using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Equipos");

            migrationBuilder.AddColumn<int>(
                name: "PrestamoId",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_PrestamoId",
                table: "Equipos",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_UsuarioId",
                table: "Prestamos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Prestamos_PrestamoId",
                table: "Equipos",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Prestamos_PrestamoId",
                table: "Equipos");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_PrestamoId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "PrestamoId",
                table: "Equipos");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Equipos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
