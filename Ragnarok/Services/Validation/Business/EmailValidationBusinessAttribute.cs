using System.ComponentModel.DataAnnotations;

namespace Ragnarok.Services.Validation.Business
{
    public class EmailValidationBusinessAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //TODO 
            return base.IsValid(value, validationContext);  
        }
    }
}
