
using Domain.Models;

namespace Repositories.Product
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(Guid id);
        Task CreateProductAsync(ProductModel product);
        Task UpdateProductAsync(Guid id, ProductModel updatedProduct);
        Task DeleteProductAsync(Guid id);
    }
}