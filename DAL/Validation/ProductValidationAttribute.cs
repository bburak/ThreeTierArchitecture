using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;


namespace DataAccessLayer.Validation
{
    public class ProductValidationAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
        $"Product Name must contain only letters!.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;
            var isNumeric = product.Name.Any(char.IsDigit);

            if (isNumeric == true)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
