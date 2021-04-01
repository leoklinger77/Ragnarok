using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Login;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ragnarok.Services.Validation.Supplier
{
    public class CPFValidationSupplierAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = value as string;

            if (!ValidationCpfOrCnpj.ValidationCpfOrCnpj.IsCpf(cpf))
            {
                return new ValidationResult(Message.MSG_CPF_Invalido);
            }

            ISupplierRepository repository = (ISupplierRepository)validationContext.GetService(typeof(ISupplierRepository));
            EmployeeLogin login = (EmployeeLogin)validationContext.GetService(typeof(EmployeeLogin));
            
            List<SupplierPhysical> list = (List<SupplierPhysical>)repository.FindByCpf(cpf,login.GetEmployee().BusinessId);
            SupplierPhysical client = (SupplierPhysical)validationContext.ObjectInstance;

            if (list.Count > 1)
            {
                return new ValidationResult(Message.MSG_CPF_Cadastrado);
            }

            if (list.Count == 1 && list[0].Id != client.Id)
            {
                return new ValidationResult(Message.MSG_CPF_Cadastrado);
            }

            return ValidationResult.Success;
        }
    }
}
