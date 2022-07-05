using Domain.Entities;
using Store.Application.Contract.Persistence;

namespace Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(StoreDbContext dbContext) : base(dbContext)
    {
    }
}
