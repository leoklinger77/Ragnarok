using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Email;
using Ragnarok.Services.Filter;
using Ragnarok.Services.KeyGenerator;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Login;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Areas.Employee.Controllers
{
    [Area("Employee")]
    [EmployeeAuthorization]
    public class EmployeeController : Controller
    {
        private readonly EmployeeLogin _employeeLogin;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionNameRepository _positionNameRepository;
        private readonly SendEmail _sendEmail;

        public EmployeeController(EmployeeLogin employeeLogin, IEmployeeRepository employeeRepository, IPositionNameRepository positionNameRepository, SendEmail sendEmail)
        {
            _employeeLogin = employeeLogin;
            _employeeRepository = employeeRepository;
            _positionNameRepository = positionNameRepository;
            _sendEmail = sendEmail;
        }
        [HttpGet]
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
            ModelState.Remove("ContactFixo.InsertDate");
            if (ModelState.IsValid)
            {
                viewModel.Employee.UpdateDate = DateTime.Now;
                viewModel.Employee.Login = viewModel.Employee.Email;
                viewModel.ContactCel.UpdateDate = DateTime.Now;
                viewModel.Employee.Contacts.Add(viewModel.ContactCel);

                if (viewModel.ContactFixo.Id > 0 && viewModel.ContactFixo.DDD is null && viewModel.ContactFixo.Number is null)
                {
                    _employeeRepository.RemoveContact(viewModel.ContactFixo.Id);
                }
                else
                {
                    if (viewModel.ContactFixo.InsertDate != null)
                    {
                        viewModel.ContactFixo.InsertDate = DateTime.Now;
                    }
                    else
                    {
                        viewModel.ContactFixo.UpdateDate = DateTime.Now;
                    }
                    viewModel.Employee.Contacts.Add(viewModel.ContactFixo);
                }
                _employeeRepository.UpdateMain(viewModel.Employee);                             
                
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
            ViewBag.PositionName = _positionNameRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x=> new SelectListItem(x.Name, x.Id.ToString()));
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Models.Employee employee)
        {
            ModelState.Remove("Employee.Login");
            ModelState.Remove("Employee.Password");
            if (ModelState.IsValid)
            {
                
                employee.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;
                employee.BusinessId = _employeeLogin.GetEmployee().BusinessId;
                employee.InsertDate = DateTime.Now;
                employee.Login = employee.Email;
                employee.Password = KeyGenerator.GetUniqueKey(8);

                employee.Address.InsertDate = DateTime.Now;

                foreach (var item in employee.Contacts)
                {
                    item.InsertDate = DateTime.Now;
                }
                TempData["MSG_S"] = Message.MSG_S_002;
                _employeeRepository.Insert(employee);
                return Json("Ok");

            }
            //TODO Implementar Regra de Validação no Front
            return Json(employee);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {           
            EmployeeFormViewModel viewModel = new EmployeeFormViewModel();
            Models.Employee employee = _employeeRepository.FindById(id);
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
            ViewBag.PositionName = _positionNameRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(EmployeeFormViewModel viewModel)
        {
            ModelState.Remove("Employee.Login");
            ModelState.Remove("Employee.Password");
            ModelState.Remove("ContactFixo.Id");
            ModelState.Remove("ContactFixo.InsertDate");
            if (ModelState.IsValid)
            {
                viewModel.Employee.UpdateDate = DateTime.Now;
                viewModel.Employee.Login = viewModel.Employee.Email;
                viewModel.ContactCel.UpdateDate = DateTime.Now;
                viewModel.Employee.Contacts.Add(viewModel.ContactCel);

                if (viewModel.ContactFixo.Id > 0 && viewModel.ContactFixo.DDD is null && viewModel.ContactFixo.Number is null)
                {                    
                    _employeeRepository.RemoveContact(viewModel.ContactFixo.Id);
                }
                else
                {                    
                    if(viewModel.ContactFixo.InsertDate != null)
                    {
                        viewModel.ContactFixo.InsertDate = DateTime.Now;
                    }
                    else
                    {
                        viewModel.ContactFixo.UpdateDate = DateTime.Now;
                    }
                    viewModel.Employee.Contacts.Add(viewModel.ContactFixo);
                }
                _employeeRepository.UpdateMain(viewModel.Employee);
                TempData["MSG_S"] = Message.MSG_S_001;
                return RedirectToAction(nameof(Details), new { id = viewModel.Employee.Id });
            }
            viewModel.Address = _employeeRepository.FindByIdAddress(viewModel.Employee.AddressId);
            ViewBag.PositionName = _positionNameRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(nameof(Details), viewModel);
        }
        [HttpGet]
        public IActionResult ResendPassword(int id)
        {
            Models.Employee employee = _employeeRepository.FindById(id);
                        
            _sendEmail.SendPasswordEmployee(employee);
            TempData["MSG_S"] = Message.MSG_S_004;            
            return RedirectToAction(nameof(Index));
        }

    }
}
