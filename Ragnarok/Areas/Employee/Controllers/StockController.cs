using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
using Ragnarok.Models.ManyToMany;
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
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepository;
        private readonly IDiscountProductStockRepository _discountProductStockRepository;
        private readonly EmployeeLogin _employeeLogin;

        public StockController(IStockRepository stockRepository, IDiscountProductStockRepository discountProductStockRepository, EmployeeLogin employeeLogin)
        {
            _stockRepository = stockRepository;
            _employeeLogin = employeeLogin;
            _discountProductStockRepository = discountProductStockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<Stock> list = await _stockRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Stock stock = await _stockRepository.FindByIdAsync(id, _employeeLogin.GetEmployee().BusinessId);
            return View(stock);
        }
        [HttpPost]
        public async Task<IActionResult> FindByProductAsync(string productBarCode)
        {
            Stock stock = await _stockRepository.FindByProductBarCodeAsync(productBarCode, _employeeLogin.GetEmployee().BusinessId);

            if (stock == null)
            {
                return Json("Error");
            }

            DiscountProductStock discount = await _discountProductStockRepository.FindByProdutDiscountAsync(stock.Id);

            ProductJsonConsultPurchase productJson = new ProductJsonConsultPurchase();
            productJson.Id = stock.Id.ToString();
            productJson.Name = stock.Product.Name;
            productJson.BarCode = stock.Product.BarCode;
            productJson.PriceSale = stock.SalesPrice;
            productJson.Discount = discount != null ? discount.DiscountProduct.DiscountAmount : 0;
            return Json(productJson);
        }
    }
}
