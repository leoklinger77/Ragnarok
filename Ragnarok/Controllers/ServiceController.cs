using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Graphics;
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
        private readonly IClientRepository _clientRepository;
        private readonly ISupplierRepository _supplierRepository;        
        private readonly EmployeeLogin _employeeLogin;

        public ServiceController(WSCorreiosAPI correiosAPI, IEmployeeRepository employeeRepository, IClientRepository clientRepository, ISupplierRepository supplierRepository, EmployeeLogin employeeLogin)
        {
            _correiosAPI = correiosAPI;
            _employeeRepository = employeeRepository;
            _clientRepository = clientRepository;
            _supplierRepository = supplierRepository;
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
        [HttpPost]
        public IActionResult ValidityInsertCPFClient(string cpf)
        {
            ICollection<ClientPhysical> list = _clientRepository.FindByCpf(cpf, _employeeLogin.GetEmployee().BusinessId);

            if (list.Count >= 1)
            {
                return Json("Cpf já cadastrado");
            }
            return Json("Ok");
        }
        [HttpPost]
        public IActionResult ValidityInsertCNPJClient(string cnpj)
        {
            ICollection<ClientJuridical> list = _clientRepository.FindByCnpj(cnpj, _employeeLogin.GetEmployee().BusinessId);

            if (list.Count >= 1)
            {
                return Json("Cnpj já cadastrado");
            }
            return Json("Ok");
        }
        [HttpPost]
        public IActionResult ValidityInsertEmailClient(string email)
        {
            ICollection<Client> list = _clientRepository.FindByEmail(email, _employeeLogin.GetEmployee().BusinessId);

            if (list.Count >= 1)
            {
                return Json("E-mail já cadastrado");
            }
            return Json("Ok");
        }
        [HttpPost]
        public IActionResult ValidityInsertCPFSupplier(string cpf)
        {
            ICollection<SupplierPhysical> list = _supplierRepository.FindByCpf(cpf, _employeeLogin.GetEmployee().BusinessId);

            if (list.Count >= 1)
            {
                return Json("Cpf já cadastrado");
            }
            return Json("Ok");
        }
        [HttpPost]
        public IActionResult ValidityInsertCNPJSupplier(string cnpj)
        {
            ICollection<SupplierJuridical> list = _supplierRepository.FindByCnpj(cnpj, _employeeLogin.GetEmployee().BusinessId);

            if (list.Count >= 1)
            {
                return Json("Cnpj já cadastrado");
            }
            return Json("Ok");
        }
        [HttpPost]
        public IActionResult ValidityInsertEmailSupplier(string email)
        {
            ICollection<Supplier> list = _supplierRepository.FindByEmail(email, _employeeLogin.GetEmployee().BusinessId);

            if (list.Count >= 1)
            {
                return Json("E-mail já cadastrado");
            }
            return Json("Ok");
        }
    }
}
