using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Persistence.Data.Migrations
{
    public partial class SeedCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AverageFuelConsumption", "Brand", "CostPerHour", "CurrentOrderId", "NumberOfSeats", "PointOfRentalId", "TransmissionType" },
                values: new object[,]
                {
                    { 1, 10, "Audi", 100, null, 4, 1, "Mechanic" },
                    { 19, 60, "Volvo", 300, null, 3, 6, "Mechanic" },
                    { 18, 75, "Volvo", 300, null, 4, 6, "Mechanic" },
                    { 17, 90, "Mercedes", 150, null, 5, 6, "Automatic" },
                    { 16, 100, "Mercedes", 160, null, 1, 6, "Mechanic" },
                    { 15, 80, "BMV", 150, null, 4, 5, "Automatic" },
                    { 14, 15, "BMV", 400, null, 2, 4, "Automatic" },
                    { 13, 90, "BMV", 150, null, 5, 4, "Automatic" },
                    { 12, 10, "Nissan", 100, null, 4, 3, "Mechanic" },
                    { 20, 200, "Volvo", 500, null, 2, 6, "Automatic" },
                    { 11, 100, "Nissan", 900, null, 3, 3, "Mechanic" },
                    { 9, 60, "Mitsubishi", 1000, null, 4, 2, "Automatic" },
                    { 8, 35, "Mitsubishi", 400, null, 1, 2, "Mechanic" },
                    { 7, 50, "Mitsubishi", 500, null, 10, 2, "Mechanic" },
                    { 6, 50, "Toyota", 500, null, 10, 2, "Mechanic" },
                    { 5, 25, "Toyota", 250, null, 2, 1, "Automatic" },
                    { 4, 15, "Toyota", 150, null, 4, 1, "Mechanic" },
                    { 3, 30, "Audi", 300, null, 6, 1, "Automatic" },
                    { 2, 20, "Audi", 200, null, 2, 1, "Mechanic" },
                    { 10, 10, "Nissan", 100, null, 4, 3, "Mechanic" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 43, 43, 133, 89, 219, 196, 245, 16, 8, 168, 13, 83, 105, 252, 10, 182, 160, 91, 72, 121, 139, 225, 188, 77, 194, 94, 126, 69, 183, 144, 76, 45, 148, 13, 221, 250, 126, 148, 204, 11, 81, 165, 192, 20, 89, 253, 44, 49, 59, 218, 83, 185, 94, 48, 181, 87, 157, 160, 54, 95, 186, 112, 179, 245 }, new byte[] { 216, 47, 168, 31, 181, 1, 197, 122, 7, 224, 95, 245, 69, 121, 139, 3, 192, 17, 14, 126, 175, 120, 146, 8, 193, 138, 200, 52, 252, 46, 254, 208, 248, 129, 61, 108, 94, 163, 151, 94, 199, 219, 205, 138, 25, 67, 242, 109, 62, 192, 15, 22, 230, 30, 249, 160, 129, 122, 49, 164, 216, 119, 190, 158, 110, 200, 69, 53, 110, 145, 157, 144, 34, 130, 74, 43, 102, 85, 3, 74, 76, 9, 44, 55, 153, 210, 173, 130, 213, 141, 215, 18, 227, 193, 211, 140, 178, 216, 53, 165, 160, 225, 162, 5, 160, 9, 40, 106, 50, 123, 90, 83, 136, 103, 1, 127, 191, 166, 64, 11, 171, 172, 117, 227, 234, 42, 128, 244 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 240, 126, 46, 99, 109, 238, 44, 51, 146, 150, 143, 137, 158, 38, 29, 220, 73, 153, 159, 92, 123, 122, 69, 31, 169, 141, 149, 207, 32, 185, 117, 227, 147, 225, 86, 103, 229, 202, 28, 61, 76, 96, 202, 28, 179, 91, 237, 110, 245, 174, 255, 176, 252, 113, 174, 111, 147, 81, 236, 109, 111, 5, 74, 19 }, new byte[] { 176, 142, 49, 104, 140, 111, 97, 113, 126, 97, 217, 55, 174, 46, 34, 189, 30, 213, 154, 136, 136, 76, 176, 223, 233, 55, 154, 237, 84, 141, 123, 139, 111, 185, 240, 190, 134, 89, 182, 140, 139, 61, 37, 226, 18, 117, 3, 245, 46, 115, 110, 47, 255, 77, 169, 164, 37, 126, 91, 224, 80, 34, 139, 236, 65, 213, 203, 229, 213, 62, 113, 179, 230, 32, 99, 209, 64, 126, 244, 57, 0, 86, 251, 62, 101, 69, 217, 230, 88, 218, 182, 252, 69, 235, 45, 97, 111, 145, 241, 30, 119, 23, 82, 121, 99, 158, 47, 107, 137, 231, 52, 79, 157, 150, 178, 204, 62, 161, 75, 17, 198, 139, 54, 211, 46, 188, 204, 221 } });
        }
    }
}
