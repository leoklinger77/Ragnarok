using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Email;
using Ragnarok.Services.FileImage;
using Ragnarok.Services.Filter;
using Ragnarok.Services.KeyGenerator;
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
        public async Task<IActionResult> Index()
        {
            ICollection<Models.Employee> list = await _employeeRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            EmployeeFormViewModel viewModel = new EmployeeFormViewModel();
            Models.Employee employee = await _employeeRepository.FindByIdAsync(_employeeLogin.GetEmployee().Id);
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
        public async Task<IActionResult> ProfileAddressUpdate(EmployeeFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Address.UpdateDate = DateTime.Now;
                _employeeRepository.UpdateAddress(viewModel.Address);
                TempData["MSG_S"] = TempData["MSG_S"] = Message.MSG_S_003;
                return RedirectToAction(nameof(Profile));
            }                       
            viewModel.Employee = await _employeeRepository.FindByIdAsync(_employeeLogin.GetEmployee().Id);
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
        public async Task<IActionResult> ProfilePasswordUpdate(EmployeeFormViewModel viewModel, string informationPassword)
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
            Models.Employee employee = await _employeeRepository.FindByIdAsync(viewModel.Employee.Id);
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
            return View(nameof(Profile), viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            ICollection<Models.PositionName> list = await _positionNameRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.PositionName = list.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
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
        public async Task<IActionResult> Details(int id)
        {           
            EmployeeFormViewModel viewModel = new EmployeeFormViewModel();
            Models.Employee employee = await _employeeRepository.FindByIdAsync(id);
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
            ICollection<Models.PositionName> list = await _positionNameRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.PositionName = list.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeFormViewModel viewModel)
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
            ICollection<Models.PositionName> list = await _positionNameRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.PositionName = list.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(nameof(Details), viewModel);
        }
        [HttpGet]
        [ValidationhttpReferer]
        public async Task<IActionResult> ResendPassword(int id)
        {
            Models.Employee employee = await _employeeRepository.FindByIdAsync(id);                        
            await _sendEmail.SendPasswordEmployeeAsync(employee);
            TempData["MSG_S"] = Message.MSG_S_004;            
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [ValidationhttpReferer]
        public IActionResult Remove(int id)
        {
            try
            {
                if (_employeeLogin.GetEmployee().Id == id)
                {
                    TempData["MSG_E"] = Message.MSG_E_004;
                    return RedirectToAction(nameof(Index));
                }
                _employeeRepository.Remove(id, _employeeLogin.GetEmployee().BusinessId);
                TempData["MSG_S"] = Message.MSG_S_005;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["MSG_E"] = Message.MSG_E_003;
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public IActionResult InsertImage(IFormFile file, int employeeId)
        {
            try
            {
                Models.Employee employee = _employeeLogin.GetEmployee();
                string path = FileManagement.UploadFileImage(file);
                if (!string.IsNullOrEmpty(path))
                {
                    FileManagement.RemoveFileImage(employee.PathImage);
                    employee.PathImage = path;                    
                    _employeeLogin.Update(_employeeRepository.UpdateImage(employee));
                    return Json(new { path = path });
                }
                return BadRequest();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

    }
}
