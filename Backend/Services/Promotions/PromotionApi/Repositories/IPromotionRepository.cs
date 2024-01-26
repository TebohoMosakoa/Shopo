using PromotionApi.Models;
using PromotionApi.Paging;
using PromotionApi.Parameters;

namespace PromotionApi.Repositories
{
    public interface IPromotionRepository
    {
        Task<PagedList<Promotion>> GetAll(QueryStringParameters parameters);
        Task<Promotion> Get(int id);
        Task<Promotion> Add(Promotion entity);
        Task<Promotion> Update(Promotion entity);
        Task<Promotion> Delete(int id);
    }
}
