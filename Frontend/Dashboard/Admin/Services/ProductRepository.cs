using Admin.DTOs;
using Admin.Features;
using Admin.Models;
using Admin.Parameter;
using Admin.Services.Shared;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Json;

namespace Admin.Services
{
	public class ProductRepository : IProductRepository
	{
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public ProductRepository(HttpClient client)
		{
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task Add(ProductDTO entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("Products", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task Delete(int id)
        {
            var url = Path.Combine("Products", id.ToString());

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();

            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }

        public async Task<Product> Get(int id)
        {
            var url = Path.Combine($"Products/", id.ToString());
            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var entity = JsonSerializer.Deserialize<Product>(content, _options);
            return entity;
        }

        public async Task<PagingResponse<Product>> GetAll(QueryStringParameters parameters)
        {
            var queryStringParam = new Dictionary<String, String>
            {
                ["pageNumber"] = parameters.PageNumber.ToString(),
                ["searchTerm"] = parameters.SearchTerm == null ? "" : parameters.SearchTerm
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString($"Products", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Product>
            {
                Items = JsonSerializer.Deserialize<List<Product>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;
        }

        public async Task Update(ProductDTO entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("Products", entity.Id.ToString());

            var postResult = await _client.PutAsync(url, bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }
    }
}
