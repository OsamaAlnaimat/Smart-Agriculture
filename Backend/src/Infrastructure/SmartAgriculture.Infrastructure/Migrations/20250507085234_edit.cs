using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAgriculture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SoilDatas_FieldId",
                table: "SoilDatas");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_FieldId",
                table: "Recommendations");

            migrationBuilder.CreateIndex(
                name: "IX_SoilDatas_FieldId",
                table: "SoilDatas",
                column: "FieldId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_FieldId",
                table: "Recommendations",
                column: "FieldId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SoilDatas_FieldId",
                table: "SoilDatas");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_FieldId",
                table: "Recommendations");

            migrationBuilder.CreateIndex(
                name: "IX_SoilDatas_FieldId",
                table: "SoilDatas",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_FieldId",
                table: "Recommendations",
                column: "FieldId");
        }
    }
}
