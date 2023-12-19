using CatalogApi.Models;
using CatalogApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : BaseController<Product, ProductRepository>
	{
		public ProductsController(ProductRepository repository) : base(repository)
		{
		}
	}
}
