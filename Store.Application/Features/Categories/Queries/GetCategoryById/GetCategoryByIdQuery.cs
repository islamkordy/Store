using Domain.Entities;
using MediatR;

namespace Store.Application.Features.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryVM>
{
    public Guid Id { get; set; }
}
