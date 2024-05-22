using Admin.DTOs;
using Admin.Features;
using Admin.Models;
using Admin.Parameter;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Json;

namespace Admin.Services.Profile
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public ProfileRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task Delete(String id)
        {
            var url = Path.Combine("Users", id.ToString());

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();

            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }

        public async Task<ProfileDTO> Get(String id)
        {
            var url = Path.Combine($"Users/", id.ToString());
            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var entity = JsonSerializer.Deserialize<ProfileDTO>(content, _options);
            return entity;
        }

        public async Task<PagingResponse<AppUser>> GetAll(QueryStringParameters parameters)
        {
            var queryStringParam = new Dictionary<String, String>
            {
                ["pageNumber"] = parameters.PageNumber.ToString(),
                ["searchTerm"] = parameters.SearchTerm == null ? "" : parameters.SearchTerm
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString($"Users", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<AppUser>
            {
                Items = JsonSerializer.Deserialize<List<AppUser>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;
        }

        public async Task Update(ProfileDTO entity)
        {
            var content = JsonSerializer.Serialize(entity);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("Users", entity.Id.ToString());

            var postResult = await _client.PutAsync(url, bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }
    }
}
