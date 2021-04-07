using Microsoft.AspNetCore.Mvc;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Login;

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
        [ValidationhttpReferer]
        public IActionResult GetOut()
        {
            _employeeLogin.Remove();
            return RedirectToAction("Index","Home", new { Area = ""});
        }
    }
}
