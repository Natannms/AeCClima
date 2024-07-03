using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeCClima.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWeatherAirport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "WeatherAirports",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Umidade = table.Column<int>(nullable: false),
                   Visibilidade = table.Column<string>(maxLength: 100, nullable: true),
                   CodigoIcao = table.Column<string>(maxLength: 4, nullable: false),
                   PressaoAtmosferica = table.Column<int>(nullable: false),
                   Vento = table.Column<int>(nullable: false),
                   DirecaoVento = table.Column<int>(nullable: false),
                   Condicao = table.Column<string>(maxLength: 100, nullable: true),
                   CondicaoDesc = table.Column<string>(maxLength: 100, nullable: true),
                   Temp = table.Column<int>(nullable: false),
                   AtualizadoEm = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_WeatherAirports", x => x.Id);
               });

            migrationBuilder.CreateIndex(
                name: "IX_CodigoIcao",
                table: "WeatherAirports",
                column: "CodigoIcao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherAirports");
        }
    }
}
