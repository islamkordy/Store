using Microsoft.EntityFrameworkCore;
using Store.Application.Common;
using Store.Application.Contract.Persistence;
using Store.Application.Exceptions;

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
        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InternalServiceError(ex.Message);
        }
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
