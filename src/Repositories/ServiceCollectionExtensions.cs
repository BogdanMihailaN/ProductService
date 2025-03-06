using Microsoft.Extensions.DependencyInjection;
using Repositories.Product;

namespace Repositories
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddProductRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            return services;
        }
    }
}