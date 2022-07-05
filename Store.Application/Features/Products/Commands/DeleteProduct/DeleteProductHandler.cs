using AutoMapper;
using Domain.Entities;
using MediatR;
using Store.Application.Contract.Persistence;

namespace Store.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        private readonly IAsyncRepository<Product> ProductRepository;
        private readonly IMapper mapper;

        public DeleteProductHandler(IAsyncRepository<Product> ProductRepository, IMapper mapper)
        {
            this.ProductRepository = ProductRepository;
            this.mapper = mapper;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var Product = mapper.Map<Product>(request);

            await ProductRepository.DeleteAsync(Product);

            return new DeleteProductCommandResponse { Success = true};
        }
    }
}
