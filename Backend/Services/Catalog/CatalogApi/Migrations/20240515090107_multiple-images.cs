using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CatalogApi.Migrations
{
    /// <inheritdoc />
    public partial class multipleimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "Image4");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Departments",
                newName: "Image4");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Categories",
                newName: "Image4");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Brands",
                newName: "Image4");

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Departments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Departments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Departments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Brands",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Brands",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Brands",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "Image4",
                table: "Products",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Image4",
                table: "Departments",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Image4",
                table: "Categories",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Image4",
                table: "Brands",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Nike" },
                    { 2, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Adidas" },
                    { 3, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Puma" },
                    { 4, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Reebok" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Sweaters" },
                    { 2, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Pants" },
                    { 3, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Jackets" },
                    { 4, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "T-Shirts" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Men" },
                    { 2, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Women" },
                    { 3, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Toddler" },
                    { 4, "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Kids" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Code", "Color", "DepartmentId", "Description", "Image", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 1, 1, 1, "1000", "Blue", 1, "Nike Sweater", "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Nike Sweater", 1000.0, "M" },
                    { 2, 2, 1, "1001", "Blue", 2, "Nike Sweater", "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Adidas Sweater", 100.0, "M" },
                    { 3, 3, 1, "1003", "Blue", 1, "Puma Sweater", "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Puma Sweater", 1000.0, "M" }
                });
        }
    }
}
