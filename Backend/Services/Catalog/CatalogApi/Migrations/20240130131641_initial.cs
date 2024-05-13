using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CatalogApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Price" },
                values: new object[] { "1000", 1000.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Code", "Color", "DepartmentId", "Description", "Image", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 2, 2, 1, "1001", "Blue", 2, "Nike Sweater", "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Adidas Sweater", 100.0, "M" },
                    { 3, 3, 1, "1003", "Blue", 1, "Puma Sweater", "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Puma Sweater", 1000.0, "M" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 100.0);
        }
    }
}
