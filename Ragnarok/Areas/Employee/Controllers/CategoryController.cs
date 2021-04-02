using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
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
    public class CategoryController : Controller
    {
        private readonly EmployeeLogin _employeeLogin;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(EmployeeLogin employeeLogin, ICategoryRepository categoryRepository)
        {
            _employeeLogin = employeeLogin;
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<Category> list = _categoryRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Category category)
        {
            if (ModelState.IsValid)
            {
                category.InsertDate = DateTime.Now;
                category.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;
                _categoryRepository.Insert(category);
                TempData["MSG_S"] = Message.MSG_S_002;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
