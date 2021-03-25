using Microsoft.AspNetCore.Mvc;
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
    public class HomeController : Controller
    {
        private readonly EmployeeLogin _employeeLogin;

        public HomeController(EmployeeLogin employeeLogin)
        {
            _employeeLogin = employeeLogin;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetOut()
        {
            _employeeLogin.Remove();
            return RedirectToAction("Index","Home", new { Area = ""});
        }
    }
}
