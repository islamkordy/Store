using AutoMapper;
using Domain.Entities;
using Store.Application.Features.Categories.Commands.CreateCategory;
using Store.Application.Features.Categories.Commands.DeleteCategory;
using Store.Application.Features.Categories.Queries;
using Store.Application.Features.Products.Commands;
using Store.Application.Features.Products.Commands.DeleteProduct;
using Store.Application.Features.Products.Queries.GetProductById;
using Store.Application.Features.Products.Queries.GetProductsList;

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
        CreateMap<Product, GetProductsListVM>().ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Categories.Name));
        CreateMap<Product, GetProductByIdVM>().ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Categories.Name));
        CreateMap<DeleteProductCommand, Product>();
    }
}
