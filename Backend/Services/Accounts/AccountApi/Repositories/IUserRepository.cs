using AccountApi.DTOs;
using AccountApi.Models;
using AccountApi.Paging;
using AccountApi.Parameters;

namespace AccountApi.Repositories
{
    public interface IUserRepository
    {
        Task<PagedList<AppUser>> GetAll(QueryStringParameters parameters);
        AppUser Get(String id);
        Task<AppUser> Update(AppUser entity);
        Task<AppUser> Delete(String id);
    }
}
