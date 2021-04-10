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
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepository;
        private readonly EmployeeLogin _employeeLogin;

        public StockController(IStockRepository stockRepository, EmployeeLogin employeeLogin)
        {
            _stockRepository = stockRepository;
            _employeeLogin = employeeLogin;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<Stock> list  = await _stockRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Stock stock = await _stockRepository.FindByIdAsync(id, _employeeLogin.GetEmployee().BusinessId);
            return View(stock);
        }

    }
}
