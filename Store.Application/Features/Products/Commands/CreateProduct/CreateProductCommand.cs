using MediatR;

namespace Store.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }
    }
}
