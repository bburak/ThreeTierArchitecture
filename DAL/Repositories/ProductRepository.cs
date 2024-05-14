using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product?> GetByIdAsync(int ProductID)
        {
            var product = await _dbContext.Products
               .FirstOrDefaultAsync(m => m.Id == ProductID);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(int AmountOfStock, int Price)
        {
            try
            {
                var products = await _dbContext.Products.ToListAsync();

                if (AmountOfStock != 0) products = products.Where(t => t.AmountOfStock == AmountOfStock).ToList();
                if (Price != 0) products = products.Where(t => t.Price == Price).ToList();
                var result = products;

                if (result != null) return result;

                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                if (product != null)
                {
                    var AddedProduct = _dbContext.Add<Product>(product);
                    await _dbContext.SaveChangesAsync();
                    return AddedProduct.Entity;
                }
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> UpdateProductAsync(int id, double price)
        {
            var updatedProduct = GetByIdAsync(id).Result;
            updatedProduct.Price = price;

            await _dbContext.SaveChangesAsync();

            return updatedProduct;
        }
    }
}
