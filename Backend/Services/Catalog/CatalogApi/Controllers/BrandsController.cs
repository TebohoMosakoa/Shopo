using CatalogApi.Models;
using CatalogApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : BaseController<Brand, BrandRepository>
	{
		public BrandsController(BrandRepository repository) : base(repository)
		{

		}
	}
}
