using CatalogApi.Data;
using CatalogApi.Models;
using CatalogApi.Paging;
using CatalogApi.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CatalogApi.Shared
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
	{
		private readonly CatalogContext _context = null;
		public RepositoryBase(CatalogContext context)
		{
			_context = context;
		}

		public async Task<T> Add(T entity)
		{
			_context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<T> Delete(int id)
		{
			var entity = await _context.Set<T>().FindAsync(id);
			if (entity == null)
			{
				return entity;
			}

			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();

			return entity;
		}


		public async Task<T> Get(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<PagedList<T>> GetAll(QueryStringParameters parameters)
		{
			if(parameters.SearchTerm != null)
			{
				var entities = await _context.Set<T>().Where(x => x.Name.ToLower() == parameters.SearchTerm.ToLower()).OrderBy(x => x.DateCreated).ToListAsync();

				return PagedList<T>
				.ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
			}

			else
			{
				var entities = await _context.Set<T>().OrderBy(x => x.DateCreated).ToListAsync();
				return PagedList<T>
				.ToPagedList(entities, parameters.PageNumber, parameters.PageSize);
			}
		}

		public async Task<T> Update(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
