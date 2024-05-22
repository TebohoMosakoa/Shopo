using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressLine", "CVV", "CardName", "CardNumber", "City", "CreatedBy", "DateCreated", "DateModified", "EmailAddress", "Expiration", "FirstName", "LastName", "ModifiedBy", "Name", "PaymentMethod", "Province", "Surburb", "TotalPrice", "UserName", "ZipCode" },
                values: new object[] { 1, "Bahcelievler", "123", "ABCD", "12345", "Roodepoort", "admin", new DateTime(2024, 5, 22, 11, 51, 0, 890, DateTimeKind.Local).AddTicks(9310), new DateTime(2024, 5, 22, 11, 51, 0, 890, DateTimeKind.Local).AddTicks(9320), "mosakoat@mail.com", "2000", "Teboho", "Mosakoa", "admin", "mosakoat@mail.com", 1, "Gauteng", "Willowbrook", 350.0, "admin", "1724" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
