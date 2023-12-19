using CatalogApi.Data;
using CatalogApi.Models;
using CatalogApi.Shared;

namespace CatalogApi.Repositories
{
	public class DepartmentRepository : RepositoryBase<Department>
	{
		public DepartmentRepository(CatalogContext _context) : base(_context)
		{

		}
	}
}
