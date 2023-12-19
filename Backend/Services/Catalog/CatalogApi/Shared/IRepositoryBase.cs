using CatalogApi.Models;
using CatalogApi.Paging;
using CatalogApi.Parameters;

namespace CatalogApi.Shared
{
	public interface IRepositoryBase<T> where T : EntityBase
	{
		Task<PagedList<T>> GetAll(QueryStringParameters parameters);
		Task<T> Get(int id);
		Task<T> Add(T entity);
		Task<T> Update(T entity);
		Task<T> Delete(int id);
	}
}
