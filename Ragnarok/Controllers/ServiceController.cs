using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Login;
using Ragnarok.Services.WebService;
using System.Collections.Generic;

namespace Ragnarok.Controllers
{
    [EmployeeAuthorization]
    public class ServiceController : Controller
    {
        private readonly WSCorreiosAPI _correiosAPI;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeLogin _employeeLogin;

        public ServiceController(WSCorreiosAPI correiosAPI, IEmployeeRepository employeeRepository, EmployeeLogin employeeLogin)
        {
            _correiosAPI = correiosAPI;
            _employeeRepository = employeeRepository;
            _employeeLogin = employeeLogin;
        }

        public IActionResult SearchByZipCode(string zipCode)
        {
            try
            {
                AddressWSCorreiosViewModel viewModel = _correiosAPI.SearchByZipCode(zipCode);
                return Json(viewModel);
            }
            catch
            {
                return Json("Cep inválido");
            }
            
        }
        [HttpPost]
        public IActionResult ValidityInsertCPFEmployee(string cpf)
        {
            ICollection<Employee> list = _employeeRepository.FindByCpf(cpf, _employeeLogin.GetEmployee().BusinessId);

            if (list.Count >= 1)
            {
                return Json("Cpf já cadastrado");
            }
            return Json("Ok");
        }

        [HttpPost]
        public IActionResult ValidityInsertEmailEmployee(string email)
        {
            ICollection<Employee> list = _employeeRepository.FindByEmail(email, _employeeLogin.GetEmployee().BusinessId);

            if (list.Count >= 1)
            {
                return Json("E-mail já cadastrado");
            }
            return Json("Ok");
        }
    }
}
