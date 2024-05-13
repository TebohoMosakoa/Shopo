using Admin.Features;
using Admin.Models;
using Admin.Parameter;

namespace Admin.Services
{
    public interface IPromotionProductRepository
    {
        Task<PagingResponse<PromotionProduct>> GetAll(QueryStringParameters parameters);
        Task Update(List<PromotionProduct> entity);
    }
}
