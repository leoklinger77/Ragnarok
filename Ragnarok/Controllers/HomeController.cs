using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Email;
using Ragnarok.Services.Login;
using System.Threading.Tasks;

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
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Login, string Password )
        {
            Employee model = _employeeRepository.Login(Login, Password);

            if (model != null)
            {
                _employeeLogin.SetEmployee(model);
                return RedirectToAction("Index", "Home", new { Area = "Employee" });
            }
            TempData["MSG_E"] = "Verifique seu E-mail ou Senha";
            return View(nameof(Index));
        }
        [HttpGet]
        public IActionResult Forgot()
        {            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotAsync(string login)
        {
            Employee model = await _employeeRepository.ForgotAsync(login);

            if (model != null)
            {
                await _sendEmail.SendPasswordEmployeeAsync(model);
                TempData["MSG_S"] = "Senda reenviada com sucesso";
                return RedirectToAction(nameof(Index));
            }
            TempData["MSG_E"] = "E-mail não localizado";
            return View();
        }
    }
}
