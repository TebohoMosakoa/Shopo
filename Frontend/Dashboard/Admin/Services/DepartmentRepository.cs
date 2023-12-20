using Admin.Models;
using Admin.Services.Shared;

namespace Admin.Services
{
	public class DepartmentRepository : RepositoryBase<Department>
	{
		public DepartmentRepository(HttpClient client) : base(client)
		{
		}
	}
}
