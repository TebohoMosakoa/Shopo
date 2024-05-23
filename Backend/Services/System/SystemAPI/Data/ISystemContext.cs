using MongoDB.Driver;
using SystemAPI.Models;

namespace SystemAPI.Data
{
    public interface ISystemContext
    {
        public IMongoCollection<Settings> Settings { get; }
    }
}
