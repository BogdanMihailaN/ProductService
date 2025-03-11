using ProductService.Domain.Models;

namespace Repositories.Product
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(int id);
        Task CreateProductAsync(ProductModel product);
        Task UpdateProductAsync(ProductModel updatedProduct);
        Task DeleteProductAsync(int id);
    }
}