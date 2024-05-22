using AccountApi.Data;
using AccountApi.Models;
using AccountApi.Paging;
using AccountApi.Parameters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UserRepository(AccountContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<AppUser> Delete(String id)
        {
            var entity = await _userManager.FindByIdAsync(id);
            if (entity == null)
            {
                await _userManager.DeleteAsync(entity);
            }

            return entity;
        }

        public AppUser Get(String id) => _context.Users.FirstOrDefault(x => x.Id == id);

        public async Task<PagedList<AppUser>> GetAll(QueryStringParameters parameters)
        {
            if (parameters.SearchTerm != null)
            {
                var entities = await _context.Users.Where(x => x.Name.ToLower() == parameters.SearchTerm.ToLower() || 
                x.Surname.ToLower() == parameters.SearchTerm.ToLower() ||
                x.Name.ToLower() + " " + x.Surname.ToLower() == parameters.SearchTerm.ToLower())
                    .ToListAsync();

                return PagedList<AppUser>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }

            else
            {
                var entities = await _context.Users
                    .ToListAsync();
                return PagedList<AppUser>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }
        }

        public async Task<AppUser> Update(AppUser entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
