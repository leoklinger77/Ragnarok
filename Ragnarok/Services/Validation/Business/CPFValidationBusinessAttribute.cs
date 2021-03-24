using Ragnarok.Repository.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ragnarok.Services.Validation.Business
{
    public class CPFValidationBusinessAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = (value as string).Trim();

            IBusinessRepository _context = (IBusinessRepository)validationContext.GetService(typeof(IBusinessRepository));
            Models.Business obj = (Models.Business)validationContext.ObjectInstance;
            List<Models.Business> list = (List<Models.Business>)_context.FindAllsCpf(cpf);

            if (list.Count > 1)
            {
                return new ValidationResult("Cpf já cadastrado");
            }

            if (list.Count ==1 && obj.Id != list[0].Id)
            {
                return new ValidationResult("Cpf já cadastrado");
            }

            return ValidationResult.Success;
        }
    }
}
