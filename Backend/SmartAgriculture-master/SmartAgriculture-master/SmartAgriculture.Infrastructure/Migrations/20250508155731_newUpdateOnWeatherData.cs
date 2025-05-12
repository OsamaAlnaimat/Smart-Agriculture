using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAgriculture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newUpdateOnWeatherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDatas_Farms_FarmId",
                table: "WeatherDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDatas_Fields_FieldId",
                table: "WeatherDatas");

            migrationBuilder.DropIndex(
                name: "IX_WeatherDatas_FieldId",
                table: "WeatherDatas");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "WeatherDatas");

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "WeatherDatas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDatas_Farms_FarmId",
                table: "WeatherDatas",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDatas_Farms_FarmId",
                table: "WeatherDatas");

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "WeatherDatas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "WeatherDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDatas_FieldId",
                table: "WeatherDatas",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDatas_Farms_FarmId",
                table: "WeatherDatas",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDatas_Fields_FieldId",
                table: "WeatherDatas",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
