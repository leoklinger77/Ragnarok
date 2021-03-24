using Ragnarok.Repository.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ragnarok.Services.Validation.Business
{
    public class EmailValidationBusinessAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = (value as string).Trim();

            IBusinessRepository _context = (IBusinessRepository)validationContext.GetService(typeof(IBusinessRepository));
            Models.Business obj = (Models.Business)validationContext.ObjectInstance;
            List<Models.Business> list = (List<Models.Business>)_context.FindAllsEmals(email);

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
