using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int ProductID);
        Task<IEnumerable<Product>> GetAllProductsAsync(int AmountOfStock, int Price);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(int id, double price);
    }
}
