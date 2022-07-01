using AutoMapper;
using Domain.Entities;
using MediatR;
using Store.Application.Contract.Persistence;

namespace Store.Application.Features.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Product> productRepository;

        public CreateProductCommandHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);

            var response = await productRepository.AddAsync(product);

            return new CreateProductCommandResponse { Id = response.Id, Success = true};
        }
    }
}
