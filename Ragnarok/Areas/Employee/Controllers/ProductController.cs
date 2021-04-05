using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ragnarok.Models;
using Ragnarok.Models.ManyToMany;
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
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryProductRepository _categoryProductRepository;
        private readonly EmployeeLogin _employeeLogin;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, ICategoryProductRepository categoryProductRepository,
            EmployeeLogin employeeLogin)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _categoryProductRepository = categoryProductRepository;
            _employeeLogin = employeeLogin;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<Product> list = _productRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            ProductFormViewModel viewModel = new ProductFormViewModel();
            ViewBag.Category = _categoryRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Insert(ProductFormViewModel viewModel)
        {
            if (viewModel.categoryList.Count == 0)
            {
                TempData["MSG_E"] = Message.MSG_E_005;
                ViewBag.Category = _categoryRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
                return View(nameof(Insert), viewModel);
            }
            if (ModelState.IsValid)
            {
                viewModel.Product.InsertDate = DateTime.Now;
                viewModel.Product.RegisterEmployeeId = _employeeLogin.GetEmployee().BusinessId;
                _productRepository.Insert(viewModel.Product);

                foreach (var item in viewModel.categoryList)
                {
                    _categoryProductRepository.Insert(new List<CategoryProduct> { new CategoryProduct { ProductId = viewModel.Product.Id, CategoryId = item } });
                }

                TempData["MSG_S"] = Message.MSG_S_002;
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Category = _categoryRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ProductFormViewModel viewModel = new ProductFormViewModel();
            viewModel.Product = _productRepository.FindById(id, _employeeLogin.GetEmployee().BusinessId);
            ViewBag.Category = _categoryRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(ProductFormViewModel viewModel)
        {

            if (viewModel.categoryList.Count == 0)
            {
                TempData["MSG_E"] = Message.MSG_E_005;
                ViewBag.Category = _categoryRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
                return View(nameof(Details), viewModel);
            }

            if (ModelState.IsValid)
            {
                viewModel.Product.UpdateDate = DateTime.Now;
                foreach (var item in viewModel.categoryList)
                {                    
                    viewModel.Product.CategoryProduct.Add(new CategoryProduct { CategoryId = item ,ProductId = viewModel.Product.Id });
                }
                List<CategoryProduct> categoryProductsDB = _categoryProductRepository.FindAllsProdut(viewModel.Product.Id).ToList();
                _categoryProductRepository.Remove(categoryProductsDB);
                _categoryProductRepository.Insert(viewModel.Product.CategoryProduct.ToList());
                _productRepository.Update(viewModel.Product);
                TempData["MSG_S"] = Message.MSG_S_001;
                return RedirectToAction(nameof(Details), new { Id = viewModel.Product.Id });

            }
            ViewBag.Category = _categoryRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(nameof(Details), viewModel);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            try
            {
                if (_employeeLogin.GetEmployee().Id == id)
                {
                    TempData["MSG_E"] = Message.MSG_E_004;
                    return RedirectToAction(nameof(Index));
                }
                _productRepository.Remove(id,_employeeLogin.GetEmployee().BusinessId);
                TempData["MSG_S"] = Message.MSG_S_005;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["MSG_E"] = Message.MSG_E_003;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult FindByProduct(int productId)
        {
            Product product = _productRepository.FindById(productId, _employeeLogin.GetEmployee().BusinessId);
            if (product == null)
            {
                return Json("Error");
            }
            ProductJsonConsultPurchase productJson = new ProductJsonConsultPurchase();
            productJson.Id = product.Id.ToString();
            productJson.Name = product.Name;
            productJson.BarCode = product.BarCode;
            return Json(productJson);
        }
    }
}
