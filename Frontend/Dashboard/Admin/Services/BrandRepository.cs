using Admin.Models;
using Admin.Services.Shared;

namespace Admin.Services
{
	public class BrandRepository : RepositoryBase<Brand>
	{
		public BrandRepository(HttpClient client) : base(client)
		{
		}
	}
}
