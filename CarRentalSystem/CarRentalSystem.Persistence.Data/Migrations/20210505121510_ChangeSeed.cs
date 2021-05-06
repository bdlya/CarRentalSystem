﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Persistence.Data.Migrations
{
    public partial class ChangeSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new byte[] { 57, 248, 185, 111, 1, 210, 152, 205, 33, 171, 178, 246, 124, 93, 251, 152, 168, 127, 112, 72, 153, 215, 129, 164, 80, 148, 67, 173, 124, 216, 12, 78, 239, 135, 152, 88, 77, 46, 56, 79, 243, 54, 28, 108, 65, 242, 219, 57, 118, 226, 235, 241, 221, 19, 220, 3, 182, 235, 231, 9, 66, 71, 45, 252 }, new byte[] { 224, 243, 181, 156, 72, 17, 140, 254, 4, 170, 226, 128, 83, 209, 204, 114, 252, 96, 119, 59, 12, 83, 170, 126, 22, 220, 12, 35, 55, 60, 205, 149, 233, 111, 63, 180, 70, 178, 99, 238, 251, 38, 232, 128, 85, 60, 248, 31, 188, 9, 29, 20, 45, 211, 184, 37, 186, 159, 28, 139, 27, 78, 22, 205, 203, 41, 218, 138, 38, 110, 213, 187, 17, 24, 114, 224, 7, 220, 35, 13, 181, 87, 252, 104, 148, 65, 169, 106, 153, 122, 80, 129, 210, 204, 0, 16, 197, 79, 80, 253, 229, 117, 51, 44, 141, 146, 224, 230, 65, 37, 9, 137, 61, 131, 3, 242, 37, 171, 168, 194, 178, 59, 53, 63, 201, 75, 213, 240 }, "AdministratorOwner" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { new byte[] { 236, 83, 207, 234, 107, 183, 178, 235, 166, 37, 73, 3, 69, 250, 25, 139, 237, 88, 24, 144, 154, 43, 140, 3, 116, 205, 159, 235, 172, 100, 166, 237, 130, 13, 39, 28, 149, 131, 118, 215, 27, 116, 66, 237, 58, 51, 125, 55, 77, 87, 40, 208, 230, 112, 4, 132, 61, 19, 104, 240, 224, 48, 57, 72 }, new byte[] { 14, 110, 170, 218, 186, 70, 217, 136, 77, 83, 71, 165, 242, 201, 18, 58, 197, 46, 178, 62, 217, 12, 246, 81, 148, 6, 55, 21, 83, 24, 91, 64, 221, 67, 186, 42, 152, 164, 203, 128, 99, 178, 87, 160, 70, 142, 68, 61, 111, 110, 161, 230, 190, 153, 178, 119, 8, 119, 183, 168, 122, 125, 106, 142, 146, 234, 114, 54, 118, 9, 194, 13, 246, 243, 42, 205, 101, 144, 99, 68, 131, 24, 142, 82, 208, 85, 98, 236, 44, 117, 123, 69, 114, 57, 102, 45, 57, 171, 32, 170, 83, 20, 68, 93, 239, 227, 58, 163, 20, 108, 120, 212, 227, 228, 37, 97, 236, 229, 143, 16, 184, 15, 52, 19, 25, 168, 4, 217 }, "AdminOwner" });
        }
    }
}
