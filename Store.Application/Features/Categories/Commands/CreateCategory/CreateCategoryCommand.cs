using MediatR;

namespace Store.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }
}
