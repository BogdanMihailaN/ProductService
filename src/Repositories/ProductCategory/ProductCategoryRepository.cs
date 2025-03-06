using Domain.Models;
using MongoDB.Driver;
using ProductService.Infrastructure;
using Repositories.ProductCategoryRepository;

namespace Repositories.ProductCategory
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly MongoDbService _mongoDbService;

        public ProductCategoryRepository(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task<List<ProductCategoryModel>> GetAllProductCategoriesAsync()
        {
            var collection = _mongoDbService.GetProductCategoriesCollection();
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<ProductCategoryModel> GetProductCategoryByIdAsync(Guid id)
        {
            var collection = _mongoDbService.GetProductCategoriesCollection();
            return await collection.Find(product => product.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateProductCategoryAsync(ProductCategoryModel product)
        {
            var collection = _mongoDbService.GetProductCategoriesCollection();
            await collection.InsertOneAsync(product);
        }

        public async Task UpdateProductCategoryAsync(Guid id, ProductCategoryModel updatedProduct)
        {
            var collection = _mongoDbService.GetProductCategoriesCollection();
            updatedProduct.Id = id;
            await collection.ReplaceOneAsync(product => product.Id == id, updatedProduct);
        }

        public async Task DeleteProductCategoryAsync(Guid id)
        {
            var collection = _mongoDbService.GetProductCategoriesCollection();
            await collection.DeleteOneAsync(product => product.Id == id);
        }
    }
}