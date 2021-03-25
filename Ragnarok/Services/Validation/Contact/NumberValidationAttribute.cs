using Ragnarok.Repository.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Ragnarok.Services.Validation.Contact
{
    public class NumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Models.Contact model = (Models.Contact)validationContext.ObjectInstance;
            if (value == null && model.TypeNumber == Models.Enums.TypeNumber.Residencial)
            {
                return ValidationResult.Success;
            }
            string number = (value as string).Trim();
            IContactRepository repository = (IContactRepository)validationContext.GetService(typeof(IContactRepository));


            if (model.TypeNumber == Models.Enums.TypeNumber.Celular && number.Length != 9)
            {
                return new ValidationResult("Número de celular invalido");
            }
            if (model.TypeNumber == Models.Enums.TypeNumber.Residencial && number.Length != 8)
            {
                return new ValidationResult("Número residencial invalido");
            }
            return ValidationResult.Success;
        }
    }
}
