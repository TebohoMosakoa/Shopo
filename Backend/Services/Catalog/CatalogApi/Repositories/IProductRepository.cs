using CatalogApi.Models;
using CatalogApi.Paging;
using CatalogApi.Parameters;

namespace CatalogApi.Repositories
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetAll(QueryStringParameters parameters);
        Task<Product> Get(int id);
        Task<Product> Add(Product entity);
        Task<Product> Update(Product entity);
        Task<Product> Delete(int id);
    }
}
