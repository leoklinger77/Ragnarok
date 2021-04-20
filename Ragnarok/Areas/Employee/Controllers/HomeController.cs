using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Login;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Areas.Employee.Controllers
{
    [Area("Employee")]
    [EmployeeAuthorization]
    public class HomeController : Controller
    {
        private readonly EmployeeLogin _employeeLogin;
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly IClientRepository _clientRepository;

        public HomeController(EmployeeLogin employeeLogin, ISalesOrderRepository salesOrderRepository, IClientRepository clientRepository)
        {
            _employeeLogin = employeeLogin;
            _salesOrderRepository = salesOrderRepository;
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            HomePageFormViewModel viewModel = new HomePageFormViewModel
            {
                SalesOrder = await _salesOrderRepository.TopSeven(_employeeLogin.GetEmployee().BusinessId),
                NumberOfClients =await _clientRepository.NumberOfClients(_employeeLogin.GetEmployee().BusinessId)
            };            
            return View(viewModel);
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
