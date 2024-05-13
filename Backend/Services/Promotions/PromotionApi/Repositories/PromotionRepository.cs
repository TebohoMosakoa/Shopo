using Microsoft.EntityFrameworkCore;
using PromotionApi.Data;
using PromotionApi.Models;
using PromotionApi.Paging;
using PromotionApi.Parameters;

namespace PromotionApi.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly PromotionContext _context = null;
        public PromotionRepository(PromotionContext context)
        {
            _context = context;
        }
        public async Task<Promotion> Add(Promotion entity)
        {
            _context.Promotions.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<Promotion> Delete(int id)
        {
            var entity = await _context.Promotions.FindAsync(id);
            _context.Promotions.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Promotion> Get(int id)
        {
            return await _context.Promotions.Where(x => x.Id == id)
                .Include(x => x.Products)
                .FirstOrDefaultAsync();
        }

        public async Task<PagedList<Promotion>> GetAll(QueryStringParameters parameters)
        {
            if (parameters.SearchTerm != null)
            {
                var entities = await _context.Promotions.Where(x => x.Name.ToLower().Contains(parameters.SearchTerm.ToLower()))
                    .ToListAsync();

                return PagedList<Promotion>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }

            if (parameters.Code != null)
            {
                var entities = await _context.Promotions.Where(x => x.Code.ToLower().Contains(parameters.Code.ToLower()))
                    .ToListAsync();

                return PagedList<Promotion>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }

            else
            {
                var entities = await _context.Promotions
                    .ToListAsync();
                return PagedList<Promotion>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }
        }

        public async Task<Promotion> Update(Promotion entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
