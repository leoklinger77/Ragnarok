using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Login;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ragnarok.Services.Validation.Employee
{
    public class EmailValidationEmployeeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = (value as string).Trim();

            IEmployeeRepository repository = (IEmployeeRepository)validationContext.GetService(typeof(IEmployeeRepository));
            EmployeeLogin login = (EmployeeLogin)validationContext.GetService(typeof(EmployeeLogin));

            List<Models.Employee> list = repository.FindByEmail(email, login.GetEmployee().BusinessId).ToList();
            Models.Employee employee = (Models.Employee)validationContext.ObjectInstance;

            if (list.Count > 1)
            {
                return new ValidationResult("E-mail já cadastrado");
            }

            if (list.Count == 1 && list[0].Id != employee.Id)
            {
                return new ValidationResult("E-mail já cadastrado");
            }
            return ValidationResult.Success;
        }
    }
}
