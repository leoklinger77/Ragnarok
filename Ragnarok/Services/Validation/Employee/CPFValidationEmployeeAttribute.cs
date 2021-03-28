using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Login;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ragnarok.Services.Validation.Employee
{
    public class CPFValidationEmployeeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            string cpf = (value as string).Trim();            

            if (!ValidationCpfOrCnpj.ValidationCpfOrCnpj.IsCpf(cpf)) {
                return new ValidationResult("CPF inválido");
            }

            IEmployeeRepository repository = (IEmployeeRepository)validationContext.GetService(typeof(IEmployeeRepository));
            EmployeeLogin login = (EmployeeLogin)validationContext.GetService(typeof(EmployeeLogin));
            Models.Employee employee = (Models.Employee)validationContext.ObjectInstance;

            List<Models.Employee> list = repository.FindByCpf(cpf, login.GetEmployee().BusinessId).ToList();

            if (list.Count > 1)
            {
                return new ValidationResult("CPF já cadastrado");
            }

            if (list.Count == 1 && list[0].Id != employee.Id)
            {
                return new ValidationResult("CPF já cadastrado");
            }
            return ValidationResult.Success;
        }
    }
}
