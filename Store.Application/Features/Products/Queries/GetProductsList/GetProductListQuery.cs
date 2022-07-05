using MediatR;

namespace Store.Application.Features.Products.Queries.GetProductsList;

public class GetProductListQuery : IRequest<List<GetProductsListVM>>
{
}
