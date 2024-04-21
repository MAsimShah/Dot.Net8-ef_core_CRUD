using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IGenericService<T>
    {
        Task AddWithSaveAsync(T entity);

        Task UpdateAsync(T entity);

        Task SaveAsync();

        Task DeleteAsync(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> List(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
    }
}