using Admin.Features;
using Admin.Models;
using Admin.Parameter;

namespace Admin.Services.Shared
{
	public interface IRepositoryBase<T> where T : EntityBase
	{
		Task<PagingResponse<T>> GetAll(string service, QueryStringParameters parameters);
		Task<T> Get(string service, int id);
		Task Add(string service, T entity);
		Task Update(string service, T entity);
		Task Delete(string service, int id);
    }
}
