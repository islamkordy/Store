using AutoMapper;
using Domain.Entities;
using MediatR;
using Store.Application.Contract.Persistence;

namespace Store.Application.Features.Products.Queries.GetProductsList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<GetProductsListVM>>
{
    private readonly IMapper mapper;
    private readonly IAsyncRepository<Product> productRepository;
    public GetProductListQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }

    public async Task<List<GetProductsListVM>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.ListAllAsync();

        return mapper.Map<List<GetProductsListVM>>(products);
    }
}
