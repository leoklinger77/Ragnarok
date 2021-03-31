using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Login;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ragnarok.Services.Validation.Client
{
    public class CNPJValidationClientAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cnpj = value as string;

            if (!ValidationCpfOrCnpj.ValidationCpfOrCnpj.IsCnpj(cnpj))
            {
                return new ValidationResult(Message.MSG_CNPJ_Invalido);
            }

            IClientRepository repository = (IClientRepository)validationContext.GetService(typeof(IClientRepository));
            EmployeeLogin login = (EmployeeLogin)validationContext.GetService(typeof(EmployeeLogin));

            List<ClientJuridical> list = (List<ClientJuridical>)repository.FindByCnpj(cnpj, login.GetEmployee().BusinessId);
            ClientJuridical client = (ClientJuridical)validationContext.ObjectInstance;

            if (list.Count > 1)
            {
                return new ValidationResult(Message.MSG_CNPJ_Cadastrado);
            }

            if (list.Count == 1 && list[0].Id != client.Id)
            {
                return new ValidationResult(Message.MSG_CNPJ_Cadastrado);
            }

            return ValidationResult.Success;
        }
    }
}
