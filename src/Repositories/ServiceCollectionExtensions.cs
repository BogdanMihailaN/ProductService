using Microsoft.Extensions.DependencyInjection;
using Repositories.Product;
using Repositories.ProductCategoryRepository;

namespace Repositories
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddProductRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategory.ProductCategoryRepository>();
            return services;
        }
    }
}