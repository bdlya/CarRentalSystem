using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Persistence.Data.Migrations
{
    public partial class SeedAdminOwnerData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "PasswordHash", "PasswordSalt", "RefreshTokenId", "Role", "SurName", "Token" },
                values: new object[] { 1, "adminOwner", "Admin", new byte[] { 236, 83, 207, 234, 107, 183, 178, 235, 166, 37, 73, 3, 69, 250, 25, 139, 237, 88, 24, 144, 154, 43, 140, 3, 116, 205, 159, 235, 172, 100, 166, 237, 130, 13, 39, 28, 149, 131, 118, 215, 27, 116, 66, 237, 58, 51, 125, 55, 77, 87, 40, 208, 230, 112, 4, 132, 61, 19, 104, 240, 224, 48, 57, 72 }, new byte[] { 14, 110, 170, 218, 186, 70, 217, 136, 77, 83, 71, 165, 242, 201, 18, 58, 197, 46, 178, 62, 217, 12, 246, 81, 148, 6, 55, 21, 83, 24, 91, 64, 221, 67, 186, 42, 152, 164, 203, 128, 99, 178, 87, 160, 70, 142, 68, 61, 111, 110, 161, 230, 190, 153, 178, 119, 8, 119, 183, 168, 122, 125, 106, 142, 146, 234, 114, 54, 118, 9, 194, 13, 246, 243, 42, 205, 101, 144, 99, 68, 131, 24, 142, 82, 208, 85, 98, 236, 44, 117, 123, 69, 114, 57, 102, 45, 57, 171, 32, 170, 83, 20, 68, 93, 239, 227, 58, 163, 20, 108, 120, 212, 227, 228, 37, 97, 236, 229, 143, 16, 184, 15, 52, 19, 25, 168, 4, 217 }, null, "AdminOwner", "Owner", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
