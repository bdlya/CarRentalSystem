using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Infrastructure.Data.Migrations
{
    public partial class ChangedRelationsBetweenCarAndOrder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CarId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentOrderId",
                table: "Cars",
                column: "CurrentOrderId",
                unique: true,
                filter: "[CurrentOrderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Orders_CurrentOrderId",
                table: "Cars",
                column: "CurrentOrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Orders_CurrentOrderId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrentOrderId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
