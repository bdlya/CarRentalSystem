using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Infrastructure.Data.Migrations
{
    public partial class RemoveConnectionBetweenOrderAndPointOfRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PointOfRentals_PointOfRentalId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PointOfRentalId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PointOfRentalId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointOfRentalId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PointOfRentalId",
                table: "Orders",
                column: "PointOfRentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PointOfRentals_PointOfRentalId",
                table: "Orders",
                column: "PointOfRentalId",
                principalTable: "PointOfRentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
