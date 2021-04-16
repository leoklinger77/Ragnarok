using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Models.ManyToMany;
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
        private readonly RagnarokContext _context;
        private readonly InventoryManagement _inventoryManagement;
        private readonly OpenBox _openBox;
        private readonly EmployeeLogin _employeeLogin;


        public SalesController(ISalesOrderRepository salesOrderRepository, ISaleBoxRepository saleBoxRepository,
            InventoryManagement inventoryManagement, IClientRepository clientRepository,
            OpenBox openBox, EmployeeLogin employeeLogin, RagnarokContext context)
        {
            _salesOrderRepository = salesOrderRepository;
            _saleBoxRepository = saleBoxRepository;
            _clientRepository = clientRepository;
            _inventoryManagement = inventoryManagement;
            _openBox = openBox;
            _employeeLogin = employeeLogin;
            _context = context;
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
            
            SalesOrder order = new SalesOrder
            {
                Client = await _clientRepository.QuickSaleAsync(_employeeLogin.GetEmployee().BusinessId)
            };
            return View(order);
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
            saleBox.Clouse = DateTime.Now;
            await _saleBoxRepository.UpdateAsync(saleBox);
            _openBox.Remove();
            return RedirectToAction(nameof(Box));
        }
        [HttpPost]
        [BoxAuthorization]
        public async Task<IActionResult> InsertSalesAsync(SalesOrder order)
        {
            using var beginTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (ModelState.IsValid)
                {
                    order.SaleBoxId = _openBox.GetSaleBox().Id;
                    order.InsertDate = DateTime.Now;

                    ICollection<SalesItem> SalesItem = new HashSet<SalesItem>();                    
                    foreach (var item in order.SalesItem)
                    {
                        if (!SalesItem.Contains(item))
                        {
                            SalesItem.Add(item);
                        }
                        else
                        {
                            SalesItem.First(x => x.StockId == item.StockId).Quantity += item.Quantity;
                        }
                    }
                    order.SalesItem = SalesItem;
                    await _inventoryManagement.StockManagementRemoveAsync(order.SalesItem, _employeeLogin.GetEmployee().BusinessId);
                    await _salesOrderRepository.InsertAsync(order);                    

                    TempData["MSG_S"] = Message.MSG_S_007;
                    await beginTransaction.CommitAsync();
                    return Json("Ok");

                }
                return Json("Invalid");
            }
            catch (Exception e)
            {
                await beginTransaction.RollbackAsync();
                return Json("Error: " + e.Message);
            }
        }
    }
}
