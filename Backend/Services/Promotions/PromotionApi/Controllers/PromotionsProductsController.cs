using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PromotionApi.Models;
using PromotionApi.Parameters;
using PromotionApi.Repositories;

namespace PromotionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public PromotionsProductsController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
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

        // POST: api/[controller]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Product> items)
        {
            QueryStringParameters parameters = new QueryStringParameters();
            parameters.PromotionId = items[0].PromotionId;
            parameters.PageNumber = 1;
            parameters.PageSize = items.Count;
            var currentProducts = await _repository.GetAll(parameters);
            var notInNewList = currentProducts.Except(items).ToList();

            foreach(var product in notInNewList)
            {
                await _repository.Delete(product.Id);
            }

            var notInCurrentList = items.Except(currentProducts).ToList();

            foreach (var product in notInCurrentList)
            {
                await _repository.Add(product);
            }

            return Created("", items);
        }
    }
}
