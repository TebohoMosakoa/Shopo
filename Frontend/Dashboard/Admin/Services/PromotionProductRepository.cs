using Admin.Features;
using Admin.Models;
using Admin.Parameter;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;

namespace Admin.Services
{
    public class PromotionProductRepository : IPromotionProductRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public PromotionProductRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<PagingResponse<PromotionProduct>> GetAll(QueryStringParameters parameters)
        {
            var queryStringParam = new Dictionary<String, String>
            {
                ["pageNumber"] = parameters.PageNumber.ToString(),
                ["searchTerm"] = parameters.SearchTerm == null ? "" : parameters.SearchTerm
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString($"PromotionsProducts", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<PromotionProduct>
            {
                Items = JsonSerializer.Deserialize<List<PromotionProduct>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;
        }

        public Task Update(List<PromotionProduct> entity)
        {
            throw new NotImplementedException();
        }
    }
}
