using AutoMapper;
using Domain.Entities;
using MediatR;
using Store.Application.Contract.Persistence;

namespace Store.Application.Features.Products.Queries.GetProductById;

public class GetProductByIDHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdVM>
{
    private readonly IMapper mapper;
    private readonly IAsyncRepository<Product> productRepository;
    public GetProductByIDHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }

    public async Task<GetProductByIdVM> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);

        return mapper.Map<GetProductByIdVM>(product);
    }
}
