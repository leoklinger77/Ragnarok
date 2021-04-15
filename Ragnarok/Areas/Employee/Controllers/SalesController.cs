using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Login;
using Ragnarok.Services.Stock;
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
        private readonly ISaleBoxRepository _saleBoxRepository;
        private readonly IClientRepository _clientRepository;        
        private readonly InventoryManagement _inventoryManagement;
        private readonly OpenBox _openBox;
        private readonly EmployeeLogin _employeeLogin;


        public SalesController(ISalesOrderRepository salesOrderRepository, ISaleBoxRepository saleBoxRepository,
            InventoryManagement inventoryManagement, IClientRepository clientRepository,
            OpenBox openBox, EmployeeLogin employeeLogin)
        {
            _salesOrderRepository = salesOrderRepository;
            _saleBoxRepository = saleBoxRepository;
            _clientRepository = clientRepository;
            _inventoryManagement = inventoryManagement;
            _openBox = openBox;
            _employeeLogin = employeeLogin;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            ICollection<SalesOrder> list = await _salesOrderRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Box()
        {   
            Dictionary<string, string> listClient = new Dictionary<string, string>();
            foreach (var item in await _clientRepository.FIndAllsAsync(_employeeLogin.GetEmployee().BusinessId))
            {
                if (item is ClientJuridical)
                {
                    ClientJuridical client = (ClientJuridical)item;
                    listClient.Add(client.Id.ToString(), client.CompanyName);
                }
                else
                {
                    ClientPhysical client = (ClientPhysical)item;
                    listClient.Add(client.Id.ToString(), client.FullName);
                }
            }
            ViewBag.Client = listClient.Select(x => new SelectListItem(x.Value, x.Key));
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> OpenSaleBoxAsync(double? ApertureValue)
        {
            if (_openBox.GetSaleBox() == null)
            {
                SaleBox box = await _saleBoxRepository.FindByHasOpenBoxAsync(_employeeLogin.GetEmployee().Id);
                if (box == null)
                {
                    SaleBox saleBox = new SaleBox();
                    saleBox.Opening = DateTime.Now;
                    saleBox.ApertureValue = (ApertureValue is null ? 0.0 : (double)ApertureValue);
                    saleBox.RegisterSalesId = _employeeLogin.GetEmployee().Id;

                    await _saleBoxRepository.InsertAsync(saleBox);
                    _openBox.SetBox(saleBox);
                    return RedirectToAction(nameof(Box));
                }
                else
                {
                    _openBox.SetBox(box);
                    return RedirectToAction(nameof(Box));
                }
            }
            return RedirectToAction(nameof(Box));
        }
        [HttpGet]
        [BoxAuthorization]
        public async Task<IActionResult> CloseSaleBoxAsync()
        {

            SaleBox saleBox = _openBox.GetSaleBox();
            saleBox.ClosingValue = 1000;
            saleBox.Clouse = DateTime.Now;
            await _saleBoxRepository.UpdateAsync(saleBox);
            _openBox.Remove();
            return RedirectToAction(nameof(Box));
        }
        [HttpPost]
        [BoxAuthorization]
        public async Task<IActionResult> InsertSalesAsync(SalesOrder order)
        {
            if (ModelState.IsValid)
            {
                order.SaleBoxId = _openBox.GetSaleBox().Id;
                order.InsertDate = DateTime.Now;

                await _inventoryManagement.StockManagementRemoveAsync(order.SalesItem, _employeeLogin.GetEmployee().BusinessId);
                await _salesOrderRepository.InsertAsync(order);

                TempData["MSG_S"] = Message.MSG_S_007;
                return Json("Ok");

            }
            return Json("Ok");
        }

    }
}
