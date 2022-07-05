using Domain.Entities;

namespace Store.Application.Contract.Persistence;

public interface IProductRepository : IAsyncRepository<Product>
{

}
