namespace Store.Application.Contract.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);

    Task<IReadOnlyList<T>> ListAllAsync();

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
