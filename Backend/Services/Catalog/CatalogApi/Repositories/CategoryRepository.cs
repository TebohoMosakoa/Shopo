using CatalogApi.Data;
using CatalogApi.Models;
using CatalogApi.Shared;

namespace CatalogApi.Repositories
{
	public class CategoryRepository : RepositoryBase<Category>
	{
		public CategoryRepository(CatalogContext _context) : base(_context)
		{

		}
	}
}
