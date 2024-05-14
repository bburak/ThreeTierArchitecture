using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var products = await _productService.CreateProduct(product);
            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] int Stock, [FromQuery] int Price)
        {
            var products = await _productService.GetProducts(Stock, Price);
            return Ok(products.ToList());
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromQuery] int id, [FromQuery] double price)
        {
            var products = await _productService.GetById(Convert.ToInt32(id));
            if (products == null)
            {
                return NotFound();
            }

            var updatedProduct = await _productService.UpdateProducts(id, price);
            return Ok(updatedProduct);
        }
    }
}
