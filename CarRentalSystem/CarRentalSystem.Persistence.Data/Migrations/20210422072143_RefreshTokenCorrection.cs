using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Persistence.Data.Migrations
{
    public partial class RefreshTokenCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefreshTokenId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenId",
                table: "Users");
        }
    }
}
