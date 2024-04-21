using DAL.AppDbContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly BookStoreContext _dbContext;
        public GenericService(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();

        public async Task AddWithSaveAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstAsync(predicate);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // search
            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }
    }
}