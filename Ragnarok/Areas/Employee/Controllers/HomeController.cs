using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Login;
using System;
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
            int businessId = _employeeLogin.GetEmployee().BusinessId;
            double valueToday = await _salesOrderRepository.ValueSold(DateTime.Now, businessId);
            double valueWeek = await _salesOrderRepository.ValueSold(DateTime.Now.AddDays(-7), businessId);
            HomePageFormViewModel viewModel = new HomePageFormViewModel
            {
                SalesOrder = await _salesOrderRepository.TopSeven(businessId),
                NumberOfClients = await _clientRepository.NumberOfClients(businessId),
                NumberOfSales = await _salesOrderRepository.SoldAmount(DateTime.Now, businessId),
                SalesVelue = valueToday,
                Growth = (valueWeek == 0) ? 0 : (((valueToday / valueWeek) - 1) * 100)
            };
            return View(viewModel);
        }
        [HttpGet]
        [ValidationhttpReferer]
        public IActionResult GetOut()
        {
            _employeeLogin.Remove();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}
