using Store.Application.Responses;

namespace Store.Application.Features.Products.Commands
{
    public class CreateProductCommandResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}
