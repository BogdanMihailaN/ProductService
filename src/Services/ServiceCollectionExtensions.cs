
using Microsoft.Extensions.DependencyInjection;
using Services.Product;
using Services.ProductCategoryService;

namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, Product.ProductService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService.ProductCategoryService>();
            return services;
        }
    }
}