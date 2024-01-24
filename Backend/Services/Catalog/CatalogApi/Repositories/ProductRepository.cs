using CatalogApi.Data;
using CatalogApi.Models;
using CatalogApi.Paging;
using CatalogApi.Parameters;
using CatalogApi.Shared;
using Microsoft.EntityFrameworkCore;

namespace CatalogApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;
        public ProductRepository(CatalogContext context)
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
            return (Product)_context.Products.Where(x => x.Id == id)
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .Include(x => x.Department);
        }

        public async Task<Product> Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PagedList<Product>> GetAll(QueryStringParameters parameters)
        {
            if (parameters.SearchTerm != null)
            {
                var entities = await _context.Products.Where(x => x.Name.ToLower() == parameters.SearchTerm.ToLower())
                    .Include(x => x.Brand)
                    .Include(x => x.Category)
                    .Include(x => x.Department)
                    .ToListAsync();

                return PagedList<Product>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }

            else
            {
                var entities = await _context.Products
                    .Include(x => x.Brand)
                    .Include(x => x.Category)
                    .Include(x => x.Department)
                    .ToListAsync();
                return PagedList<Product>
                .ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
            }
        }
    }
}
