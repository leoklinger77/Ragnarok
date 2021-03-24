using Ragnarok.Repository.Interfaces;
using System.Collections.Generic;
using Ragnarok.Models;
using System.ComponentModel.DataAnnotations;

namespace Ragnarok.Services.Validation.Business
{
    public class CNPJValidationBusinessAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cnpj = (value as string).Trim();

            IBusinessRepository _context = (IBusinessRepository)validationContext.GetService(typeof(IBusinessRepository));
            Models.Business obj = (Models.Business)validationContext.ObjectInstance;
            List<Models.BusinessJuridical> list = (List<BusinessJuridical>)_context.FindAllsCpnj(cnpj);

            if (list.Count > 1)
            {
                return new ValidationResult("Cnpj já cadastrado");
            }

            if (list.Count == 1 && obj.Id != list[0].Id)
            {
                return new ValidationResult("Cnpj já cadastrado");
            }

            return ValidationResult.Success;
        }
    }
}
