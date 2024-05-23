using MongoDB.Driver;
using SystemAPI.Data;
using SystemAPI.Models;

namespace SystemAPI.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly ISystemContext _context;

        public SettingsRepository(ISystemContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task createSettings(Settings settings)
        {
            await _context.Settings.InsertOneAsync(settings);
        }

        public async Task<Boolean> deleteSettings(string id)
        {
            FilterDefinition<Settings> filter = Builders<Settings>.Filter.Eq(w => w.Id, Convert.ToInt32(id));
            var result = await _context.Settings.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Settings>> GetSettingsAsync()
        {
            return await _context.Settings.Find(p => true).ToListAsync();
        }

        public async Task<Settings> GetSettingsAsync(string id)
        {
            return await _context.Settings.Find(p => p.Id == Convert.ToInt32(id)).FirstOrDefaultAsync();
        }

        public async Task<Boolean> updateSettings(Settings settings)
        {
            var result = await _context.Settings.ReplaceOneAsync(filter: x => x.Id == settings.Id, replacement: settings);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }
    }
}
