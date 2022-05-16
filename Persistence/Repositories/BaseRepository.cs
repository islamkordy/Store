using Microsoft.EntityFrameworkCore;
using Store.Application.Contract.Persistence;

namespace Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly StoreDbContext dbContext;

    public BaseRepository(StoreDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        dbContext.Set<T>().Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }
}
