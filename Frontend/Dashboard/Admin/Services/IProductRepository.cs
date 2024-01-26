using Admin.DTOs;
using Admin.Features;
using Admin.Models;
using Admin.Parameter;

namespace Admin.Services
{
    public interface IProductRepository
    {
        Task<PagingResponse<Product>> GetAll(QueryStringParameters parameters);
        Task<Product> Get(int id);
        Task Add(ProductDTO entity);
        Task Update(ProductDTO entity);
        Task Delete(int id);
    }
}
