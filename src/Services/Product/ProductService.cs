using ProductService.Domain.Models;
using Repositories.Product;

namespace Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task CreateProductAsync(ProductModel product)
        {
            await _productRepository.CreateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task UpdateProductAsync(int id, ProductModel updatedProduct)
        {
            updatedProduct.Id = id;
            await _productRepository.UpdateProductAsync(updatedProduct);
        }
    }
}