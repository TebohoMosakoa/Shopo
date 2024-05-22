using Admin.DTOs;
using Admin.Features;
using Admin.Models;
using Admin.Parameter;

namespace Admin.Services.Profile
{
    public interface IProfileRepository
    {
        Task<PagingResponse<AppUser>> GetAll(QueryStringParameters parameters);
        Task<ProfileDTO> Get(String id);
        Task Update(ProfileDTO entity);
        Task Delete(String id);
    }
}
