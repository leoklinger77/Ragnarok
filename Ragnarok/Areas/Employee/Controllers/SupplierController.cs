using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
using Ragnarok.Models.ViewModels;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Lang;
using Ragnarok.Services.Login;
using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> Index()
        {
            ICollection<Supplier> list = await _supplierRepository.FIndAllsAsync(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(SupplierFormViewModel supplier)
        {
            if (ModelState.IsValid)
            {
                if (supplier.SupplierJuridical != null)
                {
                    supplier.SupplierJuridical.InsertDate = DateTime.Now;
                    supplier.SupplierJuridical.Address.InsertDate = DateTime.Now;
                    foreach (var item in supplier.SupplierJuridical.Contacts)
                    {
                        item.InsertDate = DateTime.Now;
                    }
                    supplier.SupplierJuridical.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;
                    _supplierRepository.Insert(supplier.SupplierJuridical);
                }
                else
                {
                    supplier.SupplierPhysical.InsertDate = DateTime.Now;
                    supplier.SupplierPhysical.Address.InsertDate = DateTime.Now;
                    foreach (var item in supplier.SupplierPhysical.Contacts)
                    {
                        item.InsertDate = DateTime.Now;
                    }
                    supplier.SupplierPhysical.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;
                    _supplierRepository.Insert(supplier.SupplierPhysical);
                }
                TempData["MSG_S"] = Message.MSG_S_002;
                return Json("Ok");

            }
            return Json("Error");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            SupplierFormViewModel viewModel = new SupplierFormViewModel();
            Supplier client = _supplierRepository.FindById(id, _employeeLogin.GetEmployee().BusinessId);
            if (client is SupplierJuridical)
            {
                viewModel.SupplierJuridical = (SupplierJuridical)client;
            }
            else
            {
                viewModel.SupplierPhysical = (SupplierPhysical)client;
            }
            foreach (var item in client.Contacts)
            {
                if (item.TypeNumber == Models.Enums.TypeNumber.Celular)
                {
                    viewModel.Celular = item;
                }
                if (item.TypeNumber == Models.Enums.TypeNumber.Residencial)
                {
                    viewModel.Comercial = item;
                }
            }
            viewModel.Address = client.Address;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(SupplierFormViewModel supplier)
        {
            ModelState.Remove("Comercial.Id");
            ModelState.Remove("Comercial.InsertDate");
            if (ModelState.IsValid)
            {
                if (supplier.SupplierPhysical != null)
                {
                    //Atualiza Physical
                    supplier.SupplierPhysical.UpdateDate = DateTime.Now;

                    supplier.Celular.UpdateDate = DateTime.Now;
                    supplier.SupplierPhysical.Contacts.Add(supplier.Celular);
                    if (supplier.Comercial.Id == 0 && supplier.Comercial.Number != null)
                    {
                        supplier.Comercial.InsertDate = DateTime.Now;
                        supplier.SupplierPhysical.Contacts.Add(supplier.Comercial);
                    }
                    else if (supplier.Comercial.Id > 0 && supplier.Comercial.Number == null)
                    {
                        _supplierRepository.RemoveContact(supplier.Comercial.Id);
                    }
                    else if (supplier.Comercial.Id > 0 && supplier.Comercial.Number != null)
                    {
                        supplier.Comercial.UpdateDate = DateTime.Now;
                        supplier.SupplierPhysical.Contacts.Add(supplier.Comercial);
                    }

                    _supplierRepository.UpdateMain(supplier.SupplierPhysical);
                    TempData["MSG_S"] = Message.MSG_S_001;
                    return RedirectToAction(nameof(Details), new { Id = supplier.SupplierPhysical.Id });
                }
                else if (supplier.SupplierJuridical != null)
                {
                    supplier.SupplierJuridical.UpdateDate = DateTime.Now;

                    supplier.Celular.UpdateDate = DateTime.Now;
                    supplier.SupplierJuridical.Contacts.Add(supplier.Celular);
                    if (supplier.Comercial.Id == 0 && supplier.Comercial.Number != null)
                    {
                        supplier.Comercial.InsertDate = DateTime.Now;
                        supplier.SupplierJuridical.Contacts.Add(supplier.Comercial);
                    }
                    else if (supplier.Comercial.Id > 0 && supplier.Comercial.Number == null)
                    {
                        _supplierRepository.RemoveContact(supplier.Comercial.Id);
                    }
                    else if (supplier.Comercial.Id > 0 && supplier.Comercial.Number != null)
                    {
                        supplier.Comercial.UpdateDate = DateTime.Now;
                        supplier.SupplierJuridical.Contacts.Add(supplier.Comercial);
                    }

                    _supplierRepository.UpdateMain(supplier.SupplierJuridical);
                    TempData["MSG_S"] = Message.MSG_S_001;
                    return RedirectToAction(nameof(Details), new { Id = supplier.SupplierJuridical.Id });
                }
                else if (supplier.Address != null)
                {
                    supplier.Address.UpdateDate = DateTime.Now;
                    _supplierRepository.UpdateAddress(supplier.Address);

                    TempData["MSG_S"] = Message.MSG_S_001;
                    return RedirectToAction(nameof(Details), new { Id = _supplierRepository.FindTheClientIdByAddress(supplier.Address.Id) });
                }
            }
            return View(nameof(Details), supplier);
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            try
            {
                _supplierRepository.Remove(id, _employeeLogin.GetEmployee().BusinessId);
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
        public IActionResult FindBySupplier(string supplierId)
        {

            Supplier supplier = _supplierRepository.FindById(int.Parse(supplierId),_employeeLogin.GetEmployee().BusinessId);
            if (supplier == null)
            {
                return Json("Error");
            }
            SupplierJsonConsultBasic supplierJson = new SupplierJsonConsultBasic();
            supplierJson.Id = supplier.Id.ToString();
            supplierJson.Street = supplier.Address.Street;
            supplierJson.Numero = supplier.Address.Number.ToString();
            supplierJson.neighborhood = supplier.Address.Neighborhood;
            supplierJson.City = supplier.Address.City.Name;
            supplierJson.State = supplier.Address.City.State.Name;
            supplierJson.Email = supplier.Email;
            foreach (var item in supplier.Contacts)
            {
                if (item.TypeNumber == Models.Enums.TypeNumber.Celular)
                {
                    supplierJson.Phone = item.DDD + " - " + item.Number;
                }
                
            }
            if (supplier is SupplierJuridical)
            {
                SupplierJuridical juridical = (SupplierJuridical)supplier;
                supplierJson.Name = juridical.CompanyName;
            }
            else
            {
                SupplierPhysical physical = (SupplierPhysical)supplier;
                supplierJson.Name = physical.FullName;
            }
            
            return Json(supplierJson);
            
        }
    }
}
