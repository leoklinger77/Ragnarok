using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
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

        public HomeController(EmployeeLogin employeeLogin, ISalesOrderRepository salesOrderRepository)
        {
            _employeeLogin = employeeLogin;
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ICollection<SalesOrder> list = await _salesOrderRepository.TopSeven(_employeeLogin.GetEmployee().BusinessId);            
            return View(list);
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
