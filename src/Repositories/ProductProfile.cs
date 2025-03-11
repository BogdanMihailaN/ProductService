using AutoMapper;
using ProductService.Domain.Entities;
using ProductService.Domain.Models;

namespace ProductService.Repositories
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
            CreateMap<ProductCategoryModel, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryModel>();
        }
    }
}
