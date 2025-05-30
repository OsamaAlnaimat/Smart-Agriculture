using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAgriculture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditOnResponseRecommendation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recommendations_FieldId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Recommendations");

            migrationBuilder.AddColumn<string>(
                name: "advice",
                table: "Recommendations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "parameter",
                table: "Recommendations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Recommendations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "value",
                table: "Recommendations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_FieldId",
                table: "Recommendations",
                column: "FieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recommendations_FieldId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "advice",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "parameter",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "value",
                table: "Recommendations");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Recommendations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_FieldId",
                table: "Recommendations",
                column: "FieldId",
                unique: true);
        }
    }
}
