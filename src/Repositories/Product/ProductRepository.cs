using Domain.Models;
using MongoDB.Driver;
using ProductService.Infrastructure;

namespace Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoDbService _mongoDbService;

        public ProductRepository(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            var collection = _mongoDbService.GetProductCollection();
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<ProductModel> GetProductByIdAsync(Guid id)
        {
            var collection = _mongoDbService.GetProductCollection();
            return await collection.Find(product => product.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateProductAsync(ProductModel product)
        {
            var collection = _mongoDbService.GetProductCollection();
            await collection.InsertOneAsync(product);
        }

        public async Task UpdateProductAsync(Guid id, ProductModel updatedProduct)
        {
            var collection = _mongoDbService.GetProductCollection();
            updatedProduct.Id = id;
            await collection.ReplaceOneAsync(product => product.Id == id, updatedProduct);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var collection = _mongoDbService.GetProductCollection();
            await collection.DeleteOneAsync(product => product.Id == id);
        }
    }
}