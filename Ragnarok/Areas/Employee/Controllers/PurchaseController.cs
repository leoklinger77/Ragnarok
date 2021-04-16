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
    public class PurchaseController : Controller
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly EmployeeLogin _employeeLogin;
        private readonly InventoryManagement _inventoryManagement;

        public PurchaseController(IPurchaseOrderRepository purchaseOrderRepository, EmployeeLogin employeeLogin, ISupplierRepository supplierRepository,
            IProductRepository productRepository, InventoryManagement inventoryManagement)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _employeeLogin = employeeLogin;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _inventoryManagement = inventoryManagement;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<PurchaseOrder> list = await _purchaseOrderRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            Dictionary<string, string> listSupplier = new Dictionary<string, string>();
            foreach (var item in await _supplierRepository.FIndAllsAsync(_employeeLogin.GetEmployee().BusinessId))
            {
                if (item is SupplierJuridical)
                {
                    SupplierJuridical supplier = (SupplierJuridical)item;
                    listSupplier.Add(supplier.Id.ToString(), supplier.CompanyName);
                }
                else
                {
                    SupplierPhysical supplier = (SupplierPhysical)item;
                    listSupplier.Add(supplier.Id.ToString(), supplier.FullName);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(PurchaseOrder order)
        {
            if (ModelState.IsValid)
            {
                order.InsertDate = DateTime.Now;
                order.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;
                _purchaseOrderRepository.Insert(order);
                TempData["MSG_S"] = Message.MSG_S_006;
                foreach (var item in order.PurchaseItemOrder)
                {
                    await _inventoryManagement.StockManagementAddAsync(item, order.RegisterEmployeeId);
                }
                
                return Json("Ok");
            }
            return Json("Error");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            PurchaseOrder order = _purchaseOrderRepository.FindById(id, _employeeLogin.GetEmployee().BusinessId);
            return View(order);
        }
        [HttpGet]
        [ValidationhttpReferer]
        public IActionResult Remove(int id)
        {
            try
            {
                _purchaseOrderRepository.Remove(id, _employeeLogin.GetEmployee().BusinessId);
                TempData["MSG_S"] = Message.MSG_S_005;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["MSG_E"] = Message.MSG_E_003;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
