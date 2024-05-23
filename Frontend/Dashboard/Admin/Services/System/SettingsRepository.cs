using Admin.Features;
using Admin.Models;
using Appwrite.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Json;

namespace Admin.Services.System
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public SettingsRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task createSettings(Settings settings)
        {
            var content = JsonSerializer.Serialize(settings);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("Settings", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task<bool> deleteSettings(string id)
        {
            var url = Path.Combine("Settings", id.ToString());

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();

            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
            return true;
        }

        public async Task<IEnumerable<Settings>> GetSettingsAsync()
        {
            var response = await _client.GetAsync("Settings");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return (IEnumerable<Settings>)JsonSerializer.Deserialize<List<Product>>(content, _options);
        }

        public async Task<Settings> GetSettingsAsync(string id)
        {
            var url = Path.Combine($"Settings/", id.ToString());
            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var entity = JsonSerializer.Deserialize<Settings>(content, _options);
            return entity;
        }

        public async Task<bool> updateSettings(Settings settings)
        {
            var content = JsonSerializer.Serialize(settings);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("Settings", settings.Id.ToString());

            var postResult = await _client.PutAsync(url, bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            return true;
        }
    }
}
