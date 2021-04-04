using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Login;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ragnarok.Services.Validation.Client
{
    public class EmailValidationClientAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = (value as string).Trim();

            IClientRepository _context = (IClientRepository)validationContext.GetService(typeof(IClientRepository));
            EmployeeLogin login = (EmployeeLogin)validationContext.GetService(typeof(EmployeeLogin));
            Models.Client obj = (Models.Client)validationContext.ObjectInstance;
            List<Models.Client> list = (List<Models.Client>)_context.FindByEmail(email, login.GetEmployee().BusinessId);

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
