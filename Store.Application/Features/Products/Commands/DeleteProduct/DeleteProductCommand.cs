using MediatR;

namespace Store.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
