using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOnItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Items");
        }
    }
}
