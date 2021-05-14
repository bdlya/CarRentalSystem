using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Persistence.Data.Migrations
{
    public partial class SeedAdditionalWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AdditionalWorks",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 100, "Child seat" },
                    { 2, 500, "Dry cleaning" },
                    { 3, 250, "Full tank" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 193, 111, 22, 246, 77, 217, 128, 8, 72, 235, 11, 52, 127, 186, 49, 237, 95, 197, 128, 180, 195, 7, 34, 255, 128, 61, 21, 167, 141, 207, 69, 107, 2, 168, 220, 243, 175, 82, 92, 193, 71, 169, 149, 154, 244, 191, 115, 180, 51, 131, 20, 64, 77, 147, 252, 153, 197, 71, 108, 1, 46, 139, 219 }, new byte[] { 232, 20, 94, 29, 2, 201, 135, 82, 232, 170, 124, 239, 59, 233, 119, 75, 219, 31, 54, 112, 97, 103, 147, 31, 30, 116, 228, 36, 135, 218, 166, 147, 101, 19, 166, 46, 155, 178, 88, 2, 118, 129, 180, 166, 35, 231, 191, 162, 81, 6, 112, 108, 124, 233, 226, 222, 106, 22, 242, 241, 42, 250, 160, 67, 56, 36, 49, 177, 212, 122, 192, 226, 229, 239, 187, 21, 211, 73, 102, 166, 252, 239, 204, 196, 228, 248, 211, 40, 110, 30, 40, 12, 3, 2, 90, 45, 105, 203, 44, 165, 23, 193, 75, 95, 47, 229, 9, 154, 92, 139, 99, 220, 201, 151, 105, 101, 221, 134, 247, 235, 134, 228, 68, 187, 141, 95, 21, 154 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdditionalWorks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AdditionalWorks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AdditionalWorks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 43, 43, 133, 89, 219, 196, 245, 16, 8, 168, 13, 83, 105, 252, 10, 182, 160, 91, 72, 121, 139, 225, 188, 77, 194, 94, 126, 69, 183, 144, 76, 45, 148, 13, 221, 250, 126, 148, 204, 11, 81, 165, 192, 20, 89, 253, 44, 49, 59, 218, 83, 185, 94, 48, 181, 87, 157, 160, 54, 95, 186, 112, 179, 245 }, new byte[] { 216, 47, 168, 31, 181, 1, 197, 122, 7, 224, 95, 245, 69, 121, 139, 3, 192, 17, 14, 126, 175, 120, 146, 8, 193, 138, 200, 52, 252, 46, 254, 208, 248, 129, 61, 108, 94, 163, 151, 94, 199, 219, 205, 138, 25, 67, 242, 109, 62, 192, 15, 22, 230, 30, 249, 160, 129, 122, 49, 164, 216, 119, 190, 158, 110, 200, 69, 53, 110, 145, 157, 144, 34, 130, 74, 43, 102, 85, 3, 74, 76, 9, 44, 55, 153, 210, 173, 130, 213, 141, 215, 18, 227, 193, 211, 140, 178, 216, 53, 165, 160, 225, 162, 5, 160, 9, 40, 106, 50, 123, 90, 83, 136, 103, 1, 127, 191, 166, 64, 11, 171, 172, 117, 227, 234, 42, 128, 244 } });
        }
    }
}
