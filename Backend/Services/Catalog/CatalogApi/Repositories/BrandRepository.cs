using CatalogApi.Data;
using CatalogApi.Models;
using CatalogApi.Shared;

namespace CatalogApi.Repositories
{
	public class BrandRepository : RepositoryBase<Brand>
	{
		public BrandRepository(CatalogContext _context) : base(_context)
		{

		}
	}
}
