using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Login;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ragnarok.Services.Validation.Supplier
{
    public class EmailValidationSupplierAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = (value as string).Trim();

            ISupplierRepository _context = (ISupplierRepository)validationContext.GetService(typeof(ISupplierRepository));
            EmployeeLogin login = (EmployeeLogin)validationContext.GetService(typeof(EmployeeLogin));
            Models.Supplier obj = (Models.Supplier)validationContext.ObjectInstance;
            List<Models.Supplier> list = (List<Models.Supplier>)_context.FindByEmail(email, login.GetEmployee().BusinessId);

            if (list.Count > 1)
            {
                return new ValidationResult("E-mail já cadastrado");
            }
            if (list.Count == 1 && obj.Id != list[0].Id)
            {
                return new ValidationResult("E-mail já cadastrado");
            }

            return ValidationResult.Success;
        }
    }
}
