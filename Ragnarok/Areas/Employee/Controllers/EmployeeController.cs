using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Areas.Employee.Controllers
{
    [Area("Employee")]
    [EmployeeAuthorization]
    public class EmployeeController : Controller
    {
        private readonly EmployeeLogin _employeeLogin;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeLogin employeeLogin, IEmployeeRepository employeeRepository)
        {
            _employeeLogin = employeeLogin;
            _employeeRepository = employeeRepository;
        }
        
        public IActionResult Index()
        {
            ICollection<Models.Employee> list = _employeeRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public IActionResult Profile()
        {
            EmployeeFormViewModel viewModel = new EmployeeFormViewModel();
            Models.Employee employee = _employeeRepository.FindById(_employeeLogin.GetEmployee().Id);
            viewModel.Employee = employee;
            viewModel.Address = employee.Address;
            foreach (var item in employee.Contacts)
            {
                if (item.TypeNumber == Models.Enums.TypeNumber.Celular)
                {
                    viewModel.ContactCel = item;
                }
                if (item.TypeNumber == Models.Enums.TypeNumber.Residencial)
                {
                    viewModel.ContactFixo = item;
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ProfileMainUpdate(EmployeeFormViewModel viewModel)
        {
            ModelState.Remove("Employee.Action");
            ModelState.Remove("Employee.Login");
            ModelState.Remove("Employee.Password");
            ModelState.Remove("ContactFixo.Id");            
            if (ModelState.IsValid)
            {
                viewModel.Employee.UpdateDate = DateTime.Now;
                viewModel.Employee.Login = viewModel.Employee.Email;
                _employeeRepository.UpdateMain(viewModel.Employee);

                if (viewModel.ContactFixo.Id == 0 && viewModel.ContactFixo.DDD is null && viewModel.ContactFixo.Number is null)
                {
                    viewModel.ContactCel.UpdateDate = DateTime.Now;
                    _employeeRepository.UpdatePhone(new List<Models.Contact> { viewModel.ContactCel });
                }
                else if(viewModel.ContactFixo.Id == 0 && viewModel.ContactFixo.DDD != null && viewModel.ContactFixo.Number !=null)
                {   
                    
                    viewModel.ContactFixo.InsertDate = DateTime.Now;
                    viewModel.ContactFixo.EmployeeId = viewModel.Employee.Id;
                    viewModel.ContactCel.UpdateDate = DateTime.Now;

                    _employeeRepository.InsertPhone(viewModel.ContactFixo);
                    _employeeRepository.UpdatePhone(new List<Models.Contact> { viewModel.ContactCel});
                }
                else if (viewModel.ContactFixo.Id > 0 && viewModel.ContactFixo.DDD is null && viewModel.ContactFixo.Number is null)
                {
                    viewModel.ContactCel.UpdateDate = DateTime.Now;
                    _employeeRepository.RemoveContact(viewModel.ContactFixo.Id);
                    _employeeRepository.UpdatePhone(new List<Models.Contact> { viewModel.ContactCel });
                }
                else
                {
                    viewModel.ContactCel.UpdateDate = DateTime.Now;
                    viewModel.ContactFixo.UpdateDate = DateTime.Now;
                    _employeeRepository.UpdatePhone(new List<Models.Contact> { viewModel.ContactCel, viewModel.ContactFixo });
                }                               
                TempData["MSG_S"] = Message.MSG_S_001;
                _employeeLogin.Update(_employeeRepository.LoginUpdate(viewModel.Employee.Id));
                return RedirectToAction(nameof(Profile));
            }
            viewModel.Address = _employeeRepository.FindByIdAddress(viewModel.Employee.AddressId);
            return View(nameof(Profile), viewModel);
        }

        [HttpPost]
        public IActionResult ProfileAddressUpdate(EmployeeFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Address.UpdateDate = DateTime.Now;
                _employeeRepository.UpdateAddress(viewModel.Address);
                TempData["MSG_S"] = TempData["MSG_S"] = Message.MSG_S_003;
                return RedirectToAction(nameof(Profile));
            }                       
            viewModel.Employee = _employeeRepository.FindById(_employeeLogin.GetEmployee().Id);
            foreach (var item in viewModel.Employee.Contacts)
            {
                if (item.TypeNumber == Models.Enums.TypeNumber.Celular)
                {
                    viewModel.ContactCel = item;
                }
                if (item.TypeNumber == Models.Enums.TypeNumber.Residencial)
                {
                    viewModel.ContactFixo = item;
                }
            }
            return View(nameof(Profile), viewModel);
        }
        [HttpPost]
        public IActionResult ProfilePasswordUpdate(EmployeeFormViewModel viewModel, string informationPassword)
        {
            ModelState.Remove("Employee.Name");
            ModelState.Remove("Employee.CPF");
            ModelState.Remove("Employee.BirthDay");
            ModelState.Remove("Employee.Email");
            ModelState.Remove("Employee.Login");
            ModelState.Remove("Employee.Sexo");
            ModelState.Remove("Employee.Action");
            if (informationPassword == _employeeLogin.GetEmployee().Password)
            {
                if (ModelState.IsValid)
                {
                    viewModel.Employee.UpdateDate = DateTime.Now;
                    _employeeRepository.UpdatePassword(viewModel.Employee);
                    _employeeLogin.Update(_employeeRepository.LoginUpdate(viewModel.Employee.Id));
                    TempData["MSG_S"] = "Senha alterado com sucesso.";
                    return RedirectToAction(nameof(Profile));
                }
            }
            else
            {
                TempData["MSG_E"] = "Senha Invalida";
            }            
            viewModel.Address = _employeeRepository.FindByIdAddress(viewModel.Employee.AddressId);            
            foreach (var item in _employeeRepository.FindById(viewModel.Employee.Id).Contacts)
            {
                if (item.TypeNumber == Models.Enums.TypeNumber.Celular)
                {
                    viewModel.ContactCel = item;
                }
                if (item.TypeNumber == Models.Enums.TypeNumber.Residencial)
                {
                    viewModel.ContactFixo = item;
                }
            }
            return View(nameof(Profile), viewModel);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Models.Employee employee)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

    }
}
