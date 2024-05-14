using DataAccessLayer.Entities;
using System.Linq.Expressions;

namespace BusinessLogicLayer
{
    public interface IProductService
    {
        Task<Product> GetById(int id);
        Task<Product> CreateProduct(Product product);
        Task<IEnumerable<Product>> GetProducts(int AmountOfStock, int Price);
        Task<Product> UpdateProducts(int id, double price);
    }
}
