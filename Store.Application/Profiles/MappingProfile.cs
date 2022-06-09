using AutoMapper;
using Domain.Entities;
using Store.Application.Features.Categories.Commands.CreateCategory;
using Store.Application.Features.Categories.Queries;

namespace Store.Application.Features.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryListVM>().ReverseMap();
        CreateMap<Category, CategoryVM>().ReverseMap();
        CreateMap<CreateCategoryCommand, Category>();

    }
}
