using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Infrastructure.Data.Migrations
{
    public partial class AddedRefreshTokenEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshToken_Created",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshToken_Expires",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefreshToken_Id",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshToken_Revoked",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken_Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken_Created",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshToken_Expires",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshToken_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshToken_Revoked",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshToken_Token",
                table: "Users");
        }
    }
}
