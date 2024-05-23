using MongoDB.Driver;
using SystemAPI.Models;

namespace SystemAPI.Data
{
    public class SystemContext : ISystemContext
    {
        public SystemContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<String>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<String>("DatabaseSettings:DatabaseName"));

            Settings = database.GetCollection<Settings>(configuration.GetValue<String>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<Settings> Settings { get; }
    }
}
