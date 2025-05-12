using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAgriculture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newUpdateOnWeather : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeatherDatas_FarmId",
                table: "WeatherDatas");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDatas_FarmId",
                table: "WeatherDatas",
                column: "FarmId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeatherDatas_FarmId",
                table: "WeatherDatas");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDatas_FarmId",
                table: "WeatherDatas",
                column: "FarmId");
        }
    }
}
