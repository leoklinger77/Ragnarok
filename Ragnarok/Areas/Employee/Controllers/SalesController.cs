using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
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
    public class SalesController : Controller
    {
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly EmployeeLogin _employeeLogin;

        public SalesController(ISalesOrderRepository salesOrderRepository, EmployeeLogin employeeLogin)
        {
            _salesOrderRepository = salesOrderRepository;
            _employeeLogin = employeeLogin;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            ICollection<SalesOrder> list = await _salesOrderRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public IActionResult Box()
        {
            return View();
        }
        
    }
}
