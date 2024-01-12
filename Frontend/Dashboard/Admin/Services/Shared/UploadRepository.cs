using Microsoft.AspNetCore.Components.Forms;
using Supabase;
using System.Text.Json;

namespace Admin.Services.Shared
{
    public class UploadRepository : IUploadRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public UploadRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<string> UploadImage(MultipartFormDataContent content)
        {
            var postResult = await _client.PostAsync("uploads", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine("http://localhost:8000/", postContent);
                return imgUrl;
            }
        }

        private async Task<String> HandleSelected(InputFileChangeEventArgs e)
        {

            Client client = new Client(
            "https://ssofxpefzklnnhguydwz.supabase.co",
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InNzb2Z4cGVmemtsbm5oZ3V5ZHd6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTAwNTA5MTIsImV4cCI6MjAwNTYyNjkxMn0.6j-lmzZ7_R3P5ODVKvXPgPhfT-Tn8u8a3PGmKsivi3A",
            new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true,
            });

            var imageFile = e.File;
            if (imageFile == null)
                return String.Empty;
            var resizedFile = await imageFile.RequestImageFileAsync("image/png", 300, 500);
            using (var file = resizedFile.OpenReadStream(resizedFile.Size))
            {
                var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var lastIndexOfDot = imageFile.Name.LastIndexOf('.');

                string extension = imageFile.Name.Substring(lastIndexOfDot + 1);
                Guid uniqueID = Guid.NewGuid();

                string name = $"spane-{uniqueID}.{extension}";

                await client.Storage.From("spane-images").Upload(
                    memoryStream.ToArray(), name);

                string url = client.Storage.From("spane-images").GetPublicUrl(name, null);
                return url;
            }
        }
    }
}
