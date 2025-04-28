using System.Linq.Expressions;

namespace template_dotnet.Repository
{
    public interface IDboRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
