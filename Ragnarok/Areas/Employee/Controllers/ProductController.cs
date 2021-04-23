using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ragnarok.Models;
using Ragnarok.Models.ManyToMany;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Login;
using Ragnarok.Services.Report;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

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
        public async Task<IActionResult> Index(int? page, string search, int? numberPerPage)
        {
            IPagedList<Product> list = await _productRepository.FindAllsPagedListAsync(page, search, numberPerPage, _employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            ProductFormViewModel viewModel = new ProductFormViewModel();
            ICollection<Category> list = await _categoryRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.Category = list.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ProductFormViewModel viewModel)
        {
            if (viewModel.categoryList.Count == 0)
            {
                TempData["MSG_E"] = Message.MSG_E_005;
                ICollection<Category> list = await _categoryRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
                ViewBag.Category = list.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
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
            ICollection<Category> listCat = await _categoryRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.Category = listCat.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ProductFormViewModel viewModel = new ProductFormViewModel();
            viewModel.Product = _productRepository.FindById(id, _employeeLogin.GetEmployee().BusinessId);
            ICollection<Category> list = await _categoryRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.Category = list.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductFormViewModel viewModel)
        {

            if (viewModel.categoryList.Count == 0)
            {
                TempData["MSG_E"] = Message.MSG_E_005;
                ICollection<Category> list = await _categoryRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
                ViewBag.Category = list.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
                return View(nameof(Details), viewModel);
            }

            if (ModelState.IsValid)
            {
                viewModel.Product.UpdateDate = DateTime.Now;
                foreach (var item in viewModel.categoryList)
                {
                    viewModel.Product.CategoryProduct.Add(new CategoryProduct { CategoryId = item, ProductId = viewModel.Product.Id });
                }
                List<CategoryProduct> categoryProductsDB = _categoryProductRepository.FindAllsProdut(viewModel.Product.Id).ToList();
                _categoryProductRepository.Remove(categoryProductsDB);
                _categoryProductRepository.Insert(viewModel.Product.CategoryProduct.ToList());
                _productRepository.Update(viewModel.Product);
                TempData["MSG_S"] = Message.MSG_S_001;
                return RedirectToAction(nameof(Details), new { Id = viewModel.Product.Id });

            }
            ICollection<Category> listCat = await _categoryRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            ViewBag.Category = listCat.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(nameof(Details), viewModel);
        }
        [HttpGet]
        [ValidationhttpReferer]
        public IActionResult Remove(int id)
        {
            try
            {
                _productRepository.Remove(id, _employeeLogin.GetEmployee().BusinessId);
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
        [HttpPost]
        public async Task<IActionResult> FindNameOrCodeProdut(string search)
        {
            ICollection<Product> list = await _productRepository.FindNameOrCodeProdut(search, _employeeLogin.GetEmployee().BusinessId);
            if (list.Count > 0)
            {
                return Json(list);
            }
            return Json("Not found search");
            
        }        
        [HttpGet]
        public async Task<IActionResult> Report(int? page, int? numberPerPage, string search)
        {
            IPagedList<Product> list = await _productRepository.FindAllsPagedListAsync(page, search, numberPerPage, _employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public async Task<FileResult> DownloadReport(string search, DateTime? start, DateTime? end)
        {
            DateTime startDate = start ?? DateTime.Now.AddDays(-30);
            DateTime endDate = end ?? DateTime.Now;

            string path = ExcelGenerator.ArquivoExcelCotacoes.GerarArquivo<Product>(new ExcelConfigurations(),
                    (List<Product>)await _productRepository.FindAllsAsync(_employeeLogin.GetEmployee().BusinessId));

            string contentType = "application/xlsx";
            string hostServidor = HttpContext.Request.Host.Host;
            path = Path.Combine(hostServidor, path);

            return File(path, contentType, "AllsProducts.xlsx");
        }
    }
}
