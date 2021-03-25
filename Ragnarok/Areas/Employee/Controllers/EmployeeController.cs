using Microsoft.AspNetCore.Mvc;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
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
            Models.Employee employee = _employeeRepository.FindById(_employeeLogin.GetEmployee().Id) ;
            return View(employee);
        }
    }
}
