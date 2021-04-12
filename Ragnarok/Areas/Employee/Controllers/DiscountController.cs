using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ragnarok.Models;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Areas.Employee.Controllers
{
    [Area("Employee")]
    [EmployeeAuthorization]
    public class DiscountController : Controller
    {
        private readonly IDiscountStock _discountStock;
        private readonly IStockRepository _stockRepository;
        private readonly IDiscountProductStockRepository _discountProductStock;
        private readonly EmployeeLogin _employeeLogin;

        public DiscountController(IDiscountStock discountStock, IStockRepository stockRepository,
            IDiscountProductStockRepository discountProductStock, EmployeeLogin employeeLogin)
        {
            _discountStock = discountStock;
            _employeeLogin = employeeLogin;
            _discountProductStock = discountProductStock;
            _stockRepository = stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<DiscountStock> list = await _discountStock.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> InsertAsync()
        {
            ICollection<Stock> List = await _stockRepository.FindAllsProductsNotDiscount(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.Product = List.Select(x => new SelectListItem(x.Product.Name, x.ProductId.ToString()));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(DiscountStockFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.DiscountStock.InsertDate = DateTime.Now;
                viewModel.DiscountStock.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;
                //viewModel.DiscountStock.Active = true;
                await _discountStock.InsertAsync(viewModel.DiscountStock);

                foreach (var item in viewModel.ProductsList)
                {
                    await _discountProductStock.InsertAsync(new Models.ManyToMany.DiscountProductStock { DiscountProductId = viewModel.DiscountStock.Id, StockId = item });
                }
                TempData["MSG_S"] = Message.MSG_S_002;
                return RedirectToAction(nameof(Index));
            }
            ICollection<Stock> List = await _stockRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.Product = List.Select(x => new SelectListItem(x.Product.Name, x.ProductId.ToString()));
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            DiscountStockFormViewModel viewModel = new DiscountStockFormViewModel
            {
                DiscountStock = await _discountStock.FindByAsync(id, _employeeLogin.GetEmployee().BusinessId)
            };
            ICollection<Stock> List = await _stockRepository.FindAllsProductsNotDiscount(_employeeLogin.GetEmployee().BusinessId);
            foreach (var item in viewModel.DiscountStock.DiscountProductStock)
            {
                item.Stock = await _stockRepository.FindByIdAsync(item.StockId, _employeeLogin.GetEmployee().BusinessId);
                viewModel.ProductsList.Add(item.Stock.ProductId);
                List.Add(item.Stock);
            }

            ViewBag.Product = List.Select(x => new SelectListItem(x.Product.Name, x.ProductId.ToString()));
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DiscountStockFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.DiscountStock.UpdateDate = DateTime.Now;
                viewModel.DiscountStock.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;                
                await _discountStock.UpdateAsync(viewModel.DiscountStock);

                await _discountProductStock.RemoveAllsDiscountIdAsync(viewModel.DiscountStock.Id);

                foreach (var item in viewModel.ProductsList)
                {
                    await _discountProductStock.InsertAsync(new Models.ManyToMany.DiscountProductStock { DiscountProductId = viewModel.DiscountStock.Id, StockId = item });
                }

                TempData["MSG_S"] = Message.MSG_S_001;
                return RedirectToAction(nameof(Details), new { id = viewModel.DiscountStock.Id });
            }
            ICollection<Stock> List = await _stockRepository.FindAllsProductsNotDiscount(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.Product = List.Select(x => new SelectListItem(x.Product.Name, x.ProductId.ToString()));
            return View(nameof(Details), viewModel);

        }
    }
}
