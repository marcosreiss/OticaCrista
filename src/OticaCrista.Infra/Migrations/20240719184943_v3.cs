using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OticaCrista.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductItemId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ServiceItemId",
                table: "Sales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductItemId",
                table: "Sales",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceItemId",
                table: "Sales",
                type: "longtext",
                nullable: true);
        }
    }
}
