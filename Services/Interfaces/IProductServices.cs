using mshop_api.Models;
using mshop_api.Models.DTO;

namespace mshop_api.Services.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(ProductDTO product);
        Task<bool> DeleteProduct(int id);
    }
}
