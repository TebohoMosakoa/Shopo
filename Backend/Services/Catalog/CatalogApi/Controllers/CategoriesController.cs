using CatalogApi.Models;
using CatalogApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : BaseController<Category, CategoryRepository>
	{
		public CategoriesController(CategoryRepository repository) : base(repository)
		{
		}
	}
}
