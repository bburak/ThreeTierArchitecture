using DataAccessLayer.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [ProductValidation]
        public string Name { get; set; } = String.Empty;
        [StockAndPriceValidation]
        public int AmountOfStock { get; set; }
        [StockAndPriceValidation]
        public double Price { get; set; }
    }
}
