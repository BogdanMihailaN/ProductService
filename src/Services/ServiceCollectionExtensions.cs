
using Microsoft.Extensions.DependencyInjection;
using Services.Product;

namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, Product.ProductService>();
            return services;
        }
    }
}