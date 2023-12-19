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
	}
}
