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
        }

    }
}
