using CatalogApi.Models;
using CatalogApi.Parameters;
using CatalogApi.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CatalogApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public abstract class BaseController<TEntity, TRepository> : ControllerBase
		where TEntity : EntityBase
		where TRepository : IRepositoryBase<TEntity>
	{
		private readonly TRepository repository;

		protected BaseController(TRepository repository)
		{
			this.repository = repository;
		}

		// GET: api/[controller]
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] QueryStringParameters parameters)
		{
			List<TEntity> results = new List<TEntity>();
			try
			{
				var entities = await repository.GetAll(parameters);

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
			var item = await repository.Get(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// PUT: api/[controller]/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] TEntity entity)
		{
			if (id != entity.Id)
			{
				return BadRequest();
			}
			await repository.Update(entity);
			return NoContent();
		}

		// POST: api/[controller]
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] TEntity item)
		{
			if (item == null)
				return BadRequest();
			await repository.Add(item);

			return Created("", item);
		}

		// DELETE: api/[controller]/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var item = await repository.Get(id);
			if (item == null)
				return NotFound();

			await repository.Delete(item.Id);

			return NoContent();
		}
	}
}
