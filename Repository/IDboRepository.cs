namespace template_dotnet.Repository
{
    public interface IDboRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task SaveChangesAsync();
    }
}
