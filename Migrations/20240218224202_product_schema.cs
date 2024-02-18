using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mshop_api.Migrations
{
    public partial class product_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "products",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "TotalValue");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
