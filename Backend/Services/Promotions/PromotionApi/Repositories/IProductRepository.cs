using PromotionApi.Models;
using PromotionApi.Paging;
using PromotionApi.Parameters;

namespace PromotionApi.Repositories
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetAll(QueryStringParameters parameters);
        Task<Product> Get(int id);
        Task<Product> Add(Product entity);
        Task<Product> Delete(int id);
    }
}
