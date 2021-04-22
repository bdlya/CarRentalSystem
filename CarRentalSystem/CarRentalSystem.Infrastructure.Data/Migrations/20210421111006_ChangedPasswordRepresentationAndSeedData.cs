using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Infrastructure.Data.Migrations
{
    public partial class ChangedPasswordRepresentationAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_PointOfRentals_PointOfRentalId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "OrderAdditionalServices",
                keyColumns: new[] { "AdditionalServiceId", "OrderId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderAdditionalServices",
                keyColumns: new[] { "AdditionalServiceId", "OrderId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OrderAdditionalServices",
                keyColumns: new[] { "AdditionalServiceId", "OrderId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CurrentOrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CurrentOrderId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_PointOfRentals_PointOfRentalId",
                table: "Cars",
                column: "PointOfRentalId",
                principalTable: "PointOfRentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_PointOfRentals_PointOfRentalId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "Role", "SurName", "Token" },
                values: new object[] { 1, "ReadDead@gmail.com", "John", "HnEjhGC5", "Administrator", "Mars", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "Role", "SurName", "Token" },
                values: new object[] { 2, "Redemption2@gmail.com", "Arthur", "12345", "Customer", "Morgan", null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "CurrentCustomerId", "EndDate", "PointOfRentalId", "StartDate", "TotalCost" },
                values: new object[] { 1, 1, 1, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 1, new DateTime(2021, 4, 20, 12, 5, 14, 226, DateTimeKind.Local).AddTicks(5749), 0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "CurrentCustomerId", "EndDate", "PointOfRentalId", "StartDate", "TotalCost" },
                values: new object[] { 2, 2, 1, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 1, new DateTime(2021, 4, 20, 12, 5, 14, 227, DateTimeKind.Local).AddTicks(8223), 0 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CurrentOrderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CurrentOrderId",
                value: 2);

            migrationBuilder.InsertData(
                table: "OrderAdditionalServices",
                columns: new[] { "AdditionalServiceId", "OrderId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 1, 2, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_PointOfRentals_PointOfRentalId",
                table: "Cars",
                column: "PointOfRentalId",
                principalTable: "PointOfRentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
