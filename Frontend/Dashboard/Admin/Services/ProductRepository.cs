using Admin.Models;
using Admin.Services.Shared;

namespace Admin.Services
{
	public class ProductRepository : RepositoryBase<Product>
	{
		public ProductRepository(HttpClient client) : base(client)
		{
		}
	}
}
