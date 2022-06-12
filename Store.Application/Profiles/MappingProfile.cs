using AutoMapper;
using Domain.Entities;
using Store.Application.Features.Categories.Commands.CreateCategory;
using Store.Application.Features.Categories.Commands.DeleteCategory;
using Store.Application.Features.Categories.Queries;
using Store.Application.Features.Products.Commands;

namespace Store.Application.Features.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryListVM>().ReverseMap();
        CreateMap<Category, CategoryVM>().ReverseMap();
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<DeleteCategoryCommand, Category>();
        CreateMap<CreateProductCommand, Product>();
    }
}
