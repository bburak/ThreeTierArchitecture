using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System.Linq.Expressions;

namespace BusinessLogicLayer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts(int AmountOfStock, int Price)
        {
            return await _productRepository.GetAllProductsAsync(AmountOfStock, Price);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<Product> UpdateProducts(int id, double price)
        {
            return await _productRepository.UpdateProductAsync(id, price);
        }
    }
}
