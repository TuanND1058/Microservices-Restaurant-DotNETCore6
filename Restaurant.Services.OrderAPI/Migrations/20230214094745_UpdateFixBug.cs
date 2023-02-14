using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Services.OrderAPI.Migrations
{
    public partial class UpdateFixBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscounrTotal",
                table: "OrderHeaders",
                newName: "DiscountTotal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountTotal",
                table: "OrderHeaders",
                newName: "DiscounrTotal");
        }
    }
}
