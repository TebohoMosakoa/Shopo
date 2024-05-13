using CatalogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogApi.Data
{
	public class CatalogContext : DbContext
	{
		public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
		{

		}

		public DbSet<Brand> Brands { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne(_ => _.Category)
            .WithMany(a => a.Products)
            .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
            .HasOne(_ => _.Brand)
            .WithMany(a => a.Products)
            .HasForeignKey(p => p.BrandId);
            modelBuilder.Entity<Product>()
            .HasOne(_ => _.Department)
            .WithMany(a => a.Products)
            .HasForeignKey(p => p.DepartmentId);

            modelBuilder.Entity<Brand>().HasData(
                new Brand{ Id = 1, Name = "Nike", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" },
                new Brand { Id = 2, Name = "Adidas", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" },
                new Brand { Id = 3, Name = "Puma", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" },
                new Brand { Id = 4, Name = "Reebok", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sweaters", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" },
                new Category { Id = 2, Name = "Pants", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" },
                new Category { Id = 3, Name = "Jackets", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" },
                new Category { Id = 4, Name = "T-Shirts", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Men", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" },
                new Department { Id = 2, Name = "Women", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" },
                new Department { Id = 3, Name = "Toddler", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" },
                new Department { Id = 4, Name = "Kids", Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, 
                    Name = "Nike Sweater", 
                    Price = 1000,
                    Code = "1000",
                    Description = "Nike Sweater",
                    Size = "M",
                    Color = "Blue",
                    BrandId = 1,
                    CategoryId= 1,
                    DepartmentId = 1,
                    Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2,
                    Name = "Adidas Sweater",
                    Price = 100,
                    Code = "1001",
                    Description = "Nike Sweater",
                    Size = "M",
                    Color = "Blue",
                    BrandId = 2,
                    CategoryId = 1,
                    DepartmentId = 2,
                    Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg"
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 3,
                    Name = "Puma Sweater",
                    Price = 1000,
                    Code = "1003",
                    Description = "Puma Sweater",
                    Size = "M",
                    Color = "Blue",
                    BrandId = 3,
                    CategoryId = 1,
                    DepartmentId = 1,
                    Image = "https://ssofxpefzklnnhguydwz.supabase.co/storage/v1/object/public/spane-images/spane-0c56a70a-3fae-44d4-ac55-ae3a5b665a00.jpg"
                }
            );
        }

    }
}
