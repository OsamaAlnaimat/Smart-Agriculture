using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAgriculture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWeatherReadingsToFarm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "WeatherDatas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDatas_FarmId",
                table: "WeatherDatas",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDatas_Farms_FarmId",
                table: "WeatherDatas",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDatas_Farms_FarmId",
                table: "WeatherDatas");

            migrationBuilder.DropIndex(
                name: "IX_WeatherDatas_FarmId",
                table: "WeatherDatas");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "WeatherDatas");
        }
    }
}
