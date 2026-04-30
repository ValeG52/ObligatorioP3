using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnguloVision",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Apertura",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Carga",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Computarizado",
                table: "Equipos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dieametro",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisFocal",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Equipos",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelFocal",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resolucion",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sensor",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TamPixel",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoMontura",
                table: "Equipos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnguloVision",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Apertura",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Carga",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Computarizado",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Dieametro",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "DisFocal",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "RelFocal",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Resolucion",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Sensor",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "TamPixel",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "TipoMontura",
                table: "Equipos");
        }
    }
}
