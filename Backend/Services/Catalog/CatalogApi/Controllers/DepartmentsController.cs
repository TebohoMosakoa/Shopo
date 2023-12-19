using CatalogApi.Models;
using CatalogApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentsController : BaseController<Department, DepartmentRepository>
	{
		public DepartmentsController(DepartmentRepository repository) : base(repository)
		{

		}
	}
}
