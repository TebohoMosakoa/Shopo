using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CatalogApi.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipDefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "BrandId", "CategoryId", "Color", "DepartmentId", "Description", "Image", "Name", "Price", "Size" },
                values: new object[] { 1, 1, 1, "Blue", 1, "Nike Sweater", "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg", "Nike Sweater", 100.0, "M" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DepartmentId",
                table: "Products",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
