using Microsoft.EntityFrameworkCore;
using PromotionApi.Data;
using PromotionApi.Models;
using PromotionApi.Paging;
using PromotionApi.Parameters;

namespace PromotionApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PromotionContext _context = null;
        public ProductRepository(PromotionContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product entity)
        {
            _context.Products.Add(entity);
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

        public async Task<Product> Delete(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<PagedList<Product>> GetAll(QueryStringParameters parameters)
        {
            if (parameters.PromotionId != null)
            {
                var entities = await _context.Products.Where(x => x.PromotionId == parameters.PromotionId)
                    .ToListAsync();

                return PagedList<Product>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }

            if (parameters.SearchTerm != null)
            {
                var entities = await _context.Products.Where(x => x.Name.ToLower().Contains(parameters.SearchTerm.ToLower()))
                    .ToListAsync();

                return PagedList<Product>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }

            if (parameters.Code != null)
            {
                var entities = await _context.Products.Where(x => x.Code.ToLower().Contains(parameters.Code.ToLower()))
                    .ToListAsync();

                return PagedList<Product>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }

            else
            {
                var entities = await _context.Products
                    .ToListAsync();
                return PagedList<Product>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }
        }
    }
}
