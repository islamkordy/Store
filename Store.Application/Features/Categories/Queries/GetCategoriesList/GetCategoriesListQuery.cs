using MediatR;

namespace Store.Application.Features.Categories.Queries;

public class GetCategoriesListQuery : IRequest<List<CategoryListVM>>
{
}
