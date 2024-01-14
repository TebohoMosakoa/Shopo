using CatalogApi.Models;
using CatalogApi.Parameters;
using CatalogApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CatalogApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductsController(ProductRepository repository)
		{
			_repository = repository;
		}

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryStringParameters parameters)
        {
            List<Product> results = new List<Product>();
            try
            {
                var entities = await _repository.GetAll(parameters);

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(entities.MetaData));

                results = entities;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(results);
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _repository.Update(entity);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product item)
        {
            if (item == null)
                return BadRequest();
            await _repository.Add(item);

            return Created("", item);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repository.Get(id);
            if (item == null)
                return NotFound();

            await _repository.Delete(item.Id);

            return NoContent();
        }
    }
}
