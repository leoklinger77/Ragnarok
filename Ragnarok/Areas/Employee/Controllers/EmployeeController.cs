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

        [Area("Employee")]
        [EmployeeAuthorization]
        public IActionResult Index()
        {
            return View();
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
                
                //TODO trocar mensagem de Sucesso
                TempData["MSG_S"] = Message.MSG_E_001;
                _employeeLogin.Update(_employeeRepository.LoginUpdate(viewModel.Employee.Id));
                return RedirectToAction(nameof(Profile));
            }
            viewModel.Address = _employeeRepository.FindByIdAddress(viewModel.Employee.AddressId);
            return View(nameof(Profile), viewModel);
        }
    }
}
