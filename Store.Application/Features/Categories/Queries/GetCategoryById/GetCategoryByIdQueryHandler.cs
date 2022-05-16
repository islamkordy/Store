using AutoMapper;
using Domain.Entities;
using MediatR;
using Store.Application.Contract.Persistence;
using Store.Application.Features.Categories.Queries;

namespace Store.Application.Features.Categories.Commands;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryVM>
{
    private readonly IAsyncRepository<Category> categoryrepository;
    private readonly IMapper mapper;

    public GetCategoryByIdQueryHandler(IAsyncRepository<Category> categoryrepository, IMapper mapper)
    {
        this.categoryrepository = categoryrepository;
        this.mapper = mapper;
    }

    public async Task<CategoryVM> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryrepository.GetByIdAsync(request.Id);

        return mapper.Map<CategoryVM>(category);
    }
}
