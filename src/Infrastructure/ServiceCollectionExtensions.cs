using Microsoft.Extensions.DependencyInjection;
using ProductService.Infrastructure;

namespace Infrastructure
{
    public static class InfrastructureCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbService>();
            return services;
        }
    }
}