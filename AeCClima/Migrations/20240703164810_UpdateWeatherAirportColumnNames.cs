using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeCClima.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWeatherAirportColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PressaoAtmosferica",
                table: "WeatherAirports",
                newName: "pressao_atmosferica");

            migrationBuilder.RenameColumn(
                name: "DirecaoVento",
                table: "WeatherAirports",
                newName: "direcao_vento");

            migrationBuilder.RenameColumn(
                name: "CondicaoDesc",
                table: "WeatherAirports",
                newName: "condicao_desc");

            migrationBuilder.RenameColumn(
                name: "CodigoIcao",
                table: "WeatherAirports",
                newName: "codigo_icao");

            migrationBuilder.RenameColumn(
                name: "AtualizadoEm",
                table: "WeatherAirports",
                newName: "atualizado_em");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pressao_atmosferica",
                table: "WeatherAirports",
                newName: "PressaoAtmosferica");

            migrationBuilder.RenameColumn(
                name: "direcao_vento",
                table: "WeatherAirports",
                newName: "DirecaoVento");

            migrationBuilder.RenameColumn(
                name: "condicao_desc",
                table: "WeatherAirports",
                newName: "CondicaoDesc");

            migrationBuilder.RenameColumn(
                name: "codigo_icao",
                table: "WeatherAirports",
                newName: "CodigoIcao");

            migrationBuilder.RenameColumn(
                name: "atualizado_em",
                table: "WeatherAirports",
                newName: "AtualizadoEm");
        }
    }
}
