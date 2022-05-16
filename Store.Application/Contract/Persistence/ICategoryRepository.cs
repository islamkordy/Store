using Domain.Entities;

namespace Store.Application.Contract.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
}
