using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class PurchaseController : Controller
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly EmployeeLogin _employeeLogin;

        public PurchaseController(IPurchaseOrderRepository purchaseOrderRepository, EmployeeLogin employeeLogin, ISupplierRepository supplierRepository,
            IProductRepository productRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _employeeLogin = employeeLogin;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<PurchaseOrder> list = _purchaseOrderRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            Dictionary<string, string> listSupplier = new Dictionary<string, string>();
            foreach (var item in _supplierRepository.FIndAlls(_employeeLogin.GetEmployee().BusinessId))
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
            ViewBag.Supplier = listSupplier.ToList().Select(x => new SelectListItem(x.Value, x.Key));
            ViewBag.Product = _productRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x => new SelectListItem(x.Name + "-" + x.BarCode, x.Id.ToString()));

            return View();
        }
        [HttpPost]
        public IActionResult Insert(PurchaseOrder order)
        {
            if (ModelState.IsValid)
            {
                order.InsertDate = DateTime.Now;
                order.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;
                _purchaseOrderRepository.Insert(order);
                return Json("Ok");
            }
            return Json("Error");
        }
    }
}
