using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Email;
using Ragnarok.Services.Login;

namespace Ragnarok.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeLogin _employeeLogin;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly SendEmail _sendEmail;

        public HomeController(EmployeeLogin employeeLogin, IEmployeeRepository employeeRepository, SendEmail sendEmail)
        {
            _employeeLogin = employeeLogin;
            _employeeRepository = employeeRepository;
            _sendEmail = sendEmail;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Employee employee)
        {
            Employee model = _employeeRepository.Login(employee.Login, employee.Password);

            if (model != null)
            {
                _employeeLogin.SetEmployee(model);
                return RedirectToAction("Index", "Home", new { Area = "Employee" });
            }
            TempData["MSG_E"] = "Verifique seu E-mail ou Senha";
            return View();
        }
        [HttpGet]
        public IActionResult Forgot()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Forgot(Employee employee)
        {
            Employee model = _employeeRepository.Forgot(employee.Login);

            if (model != null)
            {
                _sendEmail.SendPasswordEmployee(model);
                TempData["MSG_S"] = "Senda reenviada com sucesso";
                return RedirectToAction(nameof(Index));
            }
            TempData["MSG_E"] = "E-mail não localizado";
            return View();
        }
    }
}
