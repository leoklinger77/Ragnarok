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
    public class PurchaseController : Controller
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly EmployeeLogin _employeeLogin;

        public PurchaseController(IPurchaseOrderRepository purchaseOrderRepository, EmployeeLogin employeeLogin)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _employeeLogin = employeeLogin;
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
            return View();
        }
    }
}
