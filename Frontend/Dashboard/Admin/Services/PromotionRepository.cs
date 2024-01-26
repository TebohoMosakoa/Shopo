using Admin.Models;
using Admin.Services.Shared;

namespace Admin.Services
{
    public class PromotionRepository : RepositoryBase<Promotion>
    {
        public PromotionRepository(HttpClient client) : base(client)
        {
        }
    }
}
