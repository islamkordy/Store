using AutoMapper;
using Domain.Entities;
using MediatR;
using Store.Application.Common;
using Store.Application.Contract.Persistence;
using Store.Application.Exceptions;
using Store.Application.Features.Categories.Queries;

namespace Store.Application.Features.Categories.Commands;

public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVM>>
{
    private readonly IAsyncRepository<Category> categoryRepository;
    private readonly IMapper mapper;

    public GetCategoriesListQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
    {
        this.categoryRepository = categoryRepository;
        this.mapper = mapper;
    }

    public async Task<List<CategoryListVM>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var categories = (await categoryRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);

        if (categories is null)
            throw new InternalServiceError(Constants.FailedToExcuteQuery);

        return mapper.Map<List<CategoryListVM>>(categories);
    }
}
