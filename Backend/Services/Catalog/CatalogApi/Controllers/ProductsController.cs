using AutoMapper;
using CatalogApi.DTOs;
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
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository repository, IMapper mapper)
		{
			_repository = repository;
            _mapper = mapper;
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
        public async Task<IActionResult> Put(int id, [FromBody] ProductDTO entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            var newProduct = _mapper.Map<Product>(entity);
            await _repository.Update(newProduct);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO item)
        {
            if (item == null)
                return BadRequest();
            var newProduct = _mapper.Map<Product>(item);
            await _repository.Add(newProduct);

            return Created("", newProduct);
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
