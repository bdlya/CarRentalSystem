using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Persistence.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalWorks", x => x.Id);
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
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_RefreshTokens_RefreshTokenId",
                        column: x => x.RefreshTokenId,
                        principalTable: "RefreshTokens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentCustomerId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CurrentCustomerId",
                        column: x => x.CurrentCustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderAdditionalWorks",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAdditionalWorks", x => new { x.AdditionalServiceId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderAdditionalWorks_AdditionalWorks_AdditionalServiceId",
                        column: x => x.AdditionalServiceId,
                        principalTable: "AdditionalWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAdditionalWorks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PointOfRentals",
                columns: new[] { "Id", "Address", "City", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Default address street one", "Minsk", "Belarus", "CFL" },
                    { 2, "Default address street two", "Hrodna", "Belarus", "CFL" },
                    { 3, "Default address street three", "Moscow", "Russia", "SpaceStation" },
                    { 4, "Default address street four", "Montreal", "Canada", "Independence" },
                    { 5, "Default address street five", "Toronto", "Canada", "NoTime" },
                    { 6, "Default address street six", "Toronto", "Canada", "Expensive" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "PasswordSalt", "RefreshTokenId", "Role", "SurName", "Token" },
                values: new object[] { 1, "adminOwner", "Admin", new byte[] { 240, 126, 46, 99, 109, 238, 44, 51, 146, 150, 143, 137, 158, 38, 29, 220, 73, 153, 159, 92, 123, 122, 69, 31, 169, 141, 149, 207, 32, 185, 117, 227, 147, 225, 86, 103, 229, 202, 28, 61, 76, 96, 202, 28, 179, 91, 237, 110, 245, 174, 255, 176, 252, 113, 174, 111, 147, 81, 236, 109, 111, 5, 74, 19 }, new byte[] { 176, 142, 49, 104, 140, 111, 97, 113, 126, 97, 217, 55, 174, 46, 34, 189, 30, 213, 154, 136, 136, 76, 176, 223, 233, 55, 154, 237, 84, 141, 123, 139, 111, 185, 240, 190, 134, 89, 182, 140, 139, 61, 37, 226, 18, 117, 3, 245, 46, 115, 110, 47, 255, 77, 169, 164, 37, 126, 91, 224, 80, 34, 139, 236, 65, 213, 203, 229, 213, 62, 113, 179, 230, 32, 99, 209, 64, 126, 244, 57, 0, 86, 251, 62, 101, 69, 217, 230, 88, 218, 182, 252, 69, 235, 45, 97, 111, 145, 241, 30, 119, 23, 82, 121, 99, 158, 47, 107, 137, 231, 52, 79, 157, 150, 178, 204, 62, 161, 75, 17, 198, 139, 54, 211, 46, 188, 204, 221 }, null, "AdministratorOwner", "Owner", null });

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
                name: "IX_OrderAdditionalWorks_OrderId",
                table: "OrderAdditionalWorks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CurrentCustomerId",
                table: "Orders",
                column: "CurrentCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RefreshTokenId",
                table: "Users",
                column: "RefreshTokenId",
                unique: true,
                filter: "[RefreshTokenId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "OrderAdditionalWorks");

            migrationBuilder.DropTable(
                name: "PointOfRentals");

            migrationBuilder.DropTable(
                name: "AdditionalWorks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RefreshTokens");
        }
    }
}
