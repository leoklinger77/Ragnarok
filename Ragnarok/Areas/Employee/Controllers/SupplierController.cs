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
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly EmployeeLogin _employeeLogin;

        public SupplierController(ISupplierRepository supplierRepository, EmployeeLogin employeeLogin)
        {
            _supplierRepository = supplierRepository;
            _employeeLogin = employeeLogin;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<Supplier> list = _supplierRepository.FIndAlls(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
    }
}
