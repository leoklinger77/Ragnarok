using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Login;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ragnarok.Services.Validation.Product
{
    public class BarCodeValidationProductAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string barCode = value as string;

            IProductRepository repository = (IProductRepository)validationContext.GetService(typeof(IProductRepository));
            EmployeeLogin employeeLogin = (EmployeeLogin)validationContext.GetService(typeof(EmployeeLogin));
            Models.Product product = (Models.Product)validationContext.ObjectInstance;

            List<Models.Product> list = repository.FindByBarCode(barCode, employeeLogin.GetEmployee().BusinessId).ToList();

            if (list.Count >1)
            {
                return new ValidationResult("Código de barras já cadastrado.");
            }
            if (list.Count == 1 && list[0].Id != product.Id)
            {
                return new ValidationResult("Código de barras já cadastrado.");
            }


            return ValidationResult.Success;
        }
    }
}
