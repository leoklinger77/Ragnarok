using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
using Ragnarok.Models.ManyToMany;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Login;
using Ragnarok.Services.Report;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using X.PagedList;

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
        public async Task<IActionResult> Index(int? page, int? numberPerPage, string search, DateTime? start, DateTime? end)
        {
            DateTime startDate = start ?? DateTime.Now.AddDays(-30);
            DateTime endDate = end ?? DateTime.Now;
            IPagedList<Stock> list = await _stockRepository.FindAllsPagedListAsync(page, numberPerPage, search, startDate, endDate, _employeeLogin.GetEmployee().BusinessId);
            
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> ReportAsync(int? page, int? numberPerPage, string search, DateTime? start, DateTime? end)
        {
            DateTime startDate = start ?? DateTime.Now.AddDays(-30);
            DateTime endDate = end ?? DateTime.Now;
            IPagedList<Stock> list = await _stockRepository.FindAllsPagedListAsync(page, numberPerPage, search, startDate, endDate, _employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public async Task<FileResult> DownloadReport(string search, DateTime? start, DateTime? end)
        {
            DateTime startDate = start ?? DateTime.Now.AddDays(-30);
            DateTime endDate = end ?? DateTime.Now;
            
            string path = ExcelGenerator.ArquivoExcelCotacoes.GerarArquivo<Stock>(new ExcelConfigurations(),
                    (List<Stock>)await _stockRepository.FindAllsAsync(search, startDate, endDate, _employeeLogin.GetEmployee().BusinessId));
            
            string contentType = "application/xlsx";
            string hostServidor = HttpContext.Request.Host.Host;
            path = Path.Combine(hostServidor, path);

            return File(path, contentType, "Stock.xlsx");
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
