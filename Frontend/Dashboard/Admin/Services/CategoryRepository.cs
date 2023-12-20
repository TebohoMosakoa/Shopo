using Admin.Models;
using Admin.Services.Shared;

namespace Admin.Services
{
	public class CategoryRepository : RepositoryBase<Category>
	{
		public CategoryRepository(HttpClient client) : base(client)
		{
		}
	}
}
