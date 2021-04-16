using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointOfRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfRentals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentCustomerId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointOfRentalId = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CurrentCustomerId",
                        column: x => x.CurrentCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PointOfRentals_PointOfRentalId",
                        column: x => x.PointOfRentalId,
                        principalTable: "PointOfRentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    AverageFuelConsumption = table.Column<int>(type: "int", nullable: false),
                    TransmissionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPerHour = table.Column<int>(type: "int", nullable: false),
                    CurrentOrderId = table.Column<int>(type: "int", nullable: true),
                    PointOfRentalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Orders_CurrentOrderId",
                        column: x => x.CurrentOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_PointOfRentals_PointOfRentalId",
                        column: x => x.PointOfRentalId,
                        principalTable: "PointOfRentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderAdditionalServices",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAdditionalServices", x => new { x.AdditionalServiceId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderAdditionalServices_AdditionalServices_AdditionalServiceId",
                        column: x => x.AdditionalServiceId,
                        principalTable: "AdditionalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAdditionalServices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdditionalServices",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 20, "Baby chair" },
                    { 2, 100, "Fill a full tank" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "SurName" },
                values: new object[,]
                {
                    { 1, "John", "Mars" },
                    { 2, "Arthur", "Morgan" }
                });

            migrationBuilder.InsertData(
                table: "PointOfRentals",
                columns: new[] { "Id", "Address", "City", "Country", "Name" },
                values: new object[] { 1, "First Address", "Minsk", "Belarus", "First Point" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "CurrentCustomerId", "EndDate", "PointOfRentalId", "StartDate", "TotalCost" },
                values: new object[] { 1, 1, 1, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 1, new DateTime(2021, 4, 16, 13, 20, 56, 678, DateTimeKind.Local).AddTicks(9770), 0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "CurrentCustomerId", "EndDate", "PointOfRentalId", "StartDate", "TotalCost" },
                values: new object[] { 2, 2, 2, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 1, new DateTime(2021, 4, 16, 13, 20, 56, 680, DateTimeKind.Local).AddTicks(1815), 0 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AverageFuelConsumption", "Brand", "CostPerHour", "CurrentOrderId", "NumberOfSeats", "PointOfRentalId", "TransmissionType" },
                values: new object[,]
                {
                    { 1, 100, "Nissan", 1000, 1, 2, 1, "Mechanic" },
                    { 2, 200, "Toyota", 500, 2, 4, 1, "Automatic" }
                });

            migrationBuilder.InsertData(
                table: "OrderAdditionalServices",
                columns: new[] { "AdditionalServiceId", "OrderId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 1, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentOrderId",
                table: "Cars",
                column: "CurrentOrderId",
                unique: true,
                filter: "[CurrentOrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PointOfRentalId",
                table: "Cars",
                column: "PointOfRentalId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAdditionalServices_OrderId",
                table: "OrderAdditionalServices",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CurrentCustomerId",
                table: "Orders",
                column: "CurrentCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PointOfRentalId",
                table: "Orders",
                column: "PointOfRentalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "OrderAdditionalServices");

            migrationBuilder.DropTable(
                name: "AdditionalServices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PointOfRentals");
        }
    }
}
