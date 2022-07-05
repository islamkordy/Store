using MediatR;

namespace Store.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<GetProductByIdVM>
{
    public Guid Id;
}
