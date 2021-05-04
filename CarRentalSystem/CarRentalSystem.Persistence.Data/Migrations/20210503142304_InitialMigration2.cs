using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalSystem.Persistence.Data.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointOfRentals",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AdditionalWorks",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[] { 1, 20, "Baby chair" });

            migrationBuilder.InsertData(
                table: "AdditionalWorks",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[] { 2, 100, "Fill a full tank" });

            migrationBuilder.InsertData(
                table: "PointOfRentals",
                columns: new[] { "Id", "Address", "City", "Country", "Name" },
                values: new object[] { 1, "First Address", "Minsk", "Belarus", "First Point" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AverageFuelConsumption", "Brand", "CostPerHour", "CurrentOrderId", "NumberOfSeats", "PointOfRentalId", "TransmissionType" },
                values: new object[] { 1, 100, "Nissan", 1000, null, 2, 1, "Mechanic" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AverageFuelConsumption", "Brand", "CostPerHour", "CurrentOrderId", "NumberOfSeats", "PointOfRentalId", "TransmissionType" },
                values: new object[] { 2, 200, "Toyota", 500, null, 4, 1, "Automatic" });
        }
    }
}
