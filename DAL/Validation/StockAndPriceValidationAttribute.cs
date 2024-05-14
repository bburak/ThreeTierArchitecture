using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Validation
{
    public class StockAndPriceValidationAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
        $"Stock and Price values must greater than 0!";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;
            var stockValue = product.AmountOfStock <= Decimal.Zero;
            var priceValue = product.Price <= 0.0;

            if (stockValue == true || priceValue == true)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
