using Domain.Entities;
using Store.Application.Contract.Persistence;

namespace Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(StoreDbContext dbContext) : base(dbContext)
    {
    }
}
