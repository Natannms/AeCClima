using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeCClima.Migrations
{
    /// <inheritdoc />
    public partial class RestructureModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clima_WeatherData_WeatherDataId",
                table: "Clima");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clima",
                table: "Clima");

            migrationBuilder.RenameTable(
                name: "Clima",
                newName: "Climas");

            migrationBuilder.RenameIndex(
                name: "IX_Clima_WeatherDataId",
                table: "Climas",
                newName: "IX_Climas_WeatherDataId");

            migrationBuilder.AlterColumn<int>(
                name: "WeatherDataId",
                table: "Climas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Climas",
                table: "Climas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Climas_WeatherData_WeatherDataId",
                table: "Climas",
                column: "WeatherDataId",
                principalTable: "WeatherData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Climas_WeatherData_WeatherDataId",
                table: "Climas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Climas",
                table: "Climas");

            migrationBuilder.RenameTable(
                name: "Climas",
                newName: "Clima");

            migrationBuilder.RenameIndex(
                name: "IX_Climas_WeatherDataId",
                table: "Clima",
                newName: "IX_Clima_WeatherDataId");

            migrationBuilder.AlterColumn<int>(
                name: "WeatherDataId",
                table: "Clima",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clima",
                table: "Clima",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clima_WeatherData_WeatherDataId",
                table: "Clima",
                column: "WeatherDataId",
                principalTable: "WeatherData",
                principalColumn: "Id");
        }
    }
}
