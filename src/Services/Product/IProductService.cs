using Domain.Models;
namespace Services.Product
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(Guid id);
        Task CreateProductAsync(ProductModel product);
        Task UpdateProductAsync(Guid id, ProductModel updatedProduct);
        Task DeleteProductAsync(Guid id);
    }
}