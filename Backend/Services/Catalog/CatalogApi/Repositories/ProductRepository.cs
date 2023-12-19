using CatalogApi.Data;
using CatalogApi.Models;
using CatalogApi.Shared;

namespace CatalogApi.Repositories
{
	public class ProductRepository : RepositoryBase<Product>
	{
		public ProductRepository(CatalogContext _context) : base(_context)
		{

		}
	}
}
