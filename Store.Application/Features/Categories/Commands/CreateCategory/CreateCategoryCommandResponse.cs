using Store.Application.Responses;

namespace Store.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandResponse : BaseResponse
{
    public Guid Id { get; set; }
}
