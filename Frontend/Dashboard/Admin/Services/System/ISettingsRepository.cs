using Admin.Models;

namespace Admin.Services.System
{
    public interface ISettingsRepository
    {
        Task<IEnumerable<Settings>> GetSettingsAsync();
        Task<Settings> GetSettingsAsync(string id);
        Task createSettings(Settings settings);
        Task<Boolean> updateSettings(Settings settings);
        Task<Boolean> deleteSettings(string id);
    }
}
