using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Infrastructure.Data.Migrations
{
    public partial class ChangeCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CurrentCustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 4, 20, 12, 5, 14, 226, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "Role", "SurName", "Token" },
                values: new object[] { 2, "Redemption2@gmail.com", "Arthur", "12345", "Customer", "Morgan", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "Role", "SurName", "Token" },
                values: new object[] { 1, "ReadDead@gmail.com", "John", "HnEjhGC5", "Administrator", "Mars", null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CurrentCustomerId", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 4, 20, 12, 5, 14, 227, DateTimeKind.Local).AddTicks(8223) });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_CurrentCustomerId",
                table: "Orders",
                column: "CurrentCustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_CurrentCustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

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

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "SurName" },
                values: new object[] { 1, "John", "Mars" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "SurName" },
                values: new object[] { 2, "Arthur", "Morgan" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 4, 16, 13, 20, 56, 678, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CurrentCustomerId", "StartDate" },
                values: new object[] { 2, new DateTime(2021, 4, 16, 13, 20, 56, 680, DateTimeKind.Local).AddTicks(1815) });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CurrentCustomerId",
                table: "Orders",
                column: "CurrentCustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
