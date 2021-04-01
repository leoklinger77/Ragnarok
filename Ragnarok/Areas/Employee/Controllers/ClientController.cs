using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models;
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
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly EmployeeLogin _employeeLogin;

        public ClientController(IClientRepository clientRepository, EmployeeLogin employeeLogin)
        {
            _clientRepository = clientRepository;
            _employeeLogin = employeeLogin;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<Client> list = _clientRepository.FIndAlls(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(ClientFormViewModel client)
        {
            if (ModelState.IsValid)
            {
                if (client.ClientJuridical != null)
                {
                    client.ClientJuridical.InsertDate = DateTime.Now;
                    client.ClientJuridical.Address.InsertDate = DateTime.Now;
                    foreach (var item in client.ClientJuridical.Contacts)
                    {
                        item.InsertDate = DateTime.Now;
                    }
                    client.ClientJuridical.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;
                    _clientRepository.Insert(client.ClientJuridical);
                }
                else
                {
                    client.ClientPhysical.InsertDate = DateTime.Now;
                    client.ClientPhysical.Address.InsertDate = DateTime.Now;
                    foreach (var item in client.ClientPhysical.Contacts)
                    {
                        item.InsertDate = DateTime.Now;
                    }
                    client.ClientPhysical.RegisterEmployeeId = _employeeLogin.GetEmployee().Id;
                    _clientRepository.Insert(client.ClientPhysical);
                }
                TempData["MSG_S"] = Message.MSG_S_002;
                return Json("Ok");

            }
            return Json("Error");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ClientFormViewModel viewModel = new ClientFormViewModel();
            Client client = _clientRepository.FindById(id, _employeeLogin.GetEmployee().BusinessId);
            if (client is ClientJuridical)
            {
                viewModel.ClientJuridical = (ClientJuridical)client;
            }
            else
            {
                viewModel.ClientPhysical = (ClientPhysical)client;
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
        public IActionResult Update(ClientFormViewModel client)
        {
            ModelState.Remove("Comercial.Id");
            ModelState.Remove("Comercial.InsertDate");
            if (ModelState.IsValid)
            {
                if (client.ClientPhysical != null)
                {
                    //Atualiza Physical
                    client.ClientPhysical.UpdateDate = DateTime.Now;

                    client.Celular.UpdateDate = DateTime.Now;
                    client.ClientPhysical.Contacts.Add(client.Celular);
                    if (client.Comercial.Id == 0 && client.Comercial.Number != null)
                    {
                        client.Comercial.InsertDate = DateTime.Now;
                        client.ClientPhysical.Contacts.Add(client.Comercial);
                    }
                    else if (client.Comercial.Id > 0 && client.Comercial.Number == null)
                    {
                        _clientRepository.RemoveContact(client.Comercial.Id);
                    }
                    else if (client.Comercial.Id > 0 && client.Comercial.Number != null)
                    {
                        client.Comercial.UpdateDate = DateTime.Now;
                        client.ClientPhysical.Contacts.Add(client.Comercial);
                    }

                    _clientRepository.UpdateMain(client.ClientPhysical);
                    TempData["MSG_S"] = Message.MSG_S_001;
                    return RedirectToAction(nameof(Details), new { Id = client.ClientPhysical.Id });
                }
                else if (client.ClientJuridical != null)
                {
                    client.ClientJuridical.UpdateDate = DateTime.Now;

                    client.Celular.UpdateDate = DateTime.Now;
                    client.ClientJuridical.Contacts.Add(client.Celular);
                    if (client.Comercial.Id == 0 && client.Comercial.Number != null)
                    {
                        client.Comercial.InsertDate = DateTime.Now;
                        client.ClientJuridical.Contacts.Add(client.Comercial);
                    }
                    else if (client.Comercial.Id > 0 && client.Comercial.Number == null)
                    {
                        _clientRepository.RemoveContact(client.Comercial.Id);
                    }
                    else if (client.Comercial.Id > 0 && client.Comercial.Number != null)
                    {
                        client.Comercial.UpdateDate = DateTime.Now;
                        client.ClientJuridical.Contacts.Add(client.Comercial);
                    }                  

                    _clientRepository.UpdateMain(client.ClientJuridical);
                    TempData["MSG_S"] = Message.MSG_S_001;
                    return RedirectToAction(nameof(Details), new { Id = client.ClientJuridical.Id });
                }
                else if (client.Address != null)
                {
                    client.Address.UpdateDate = DateTime.Now;
                    _clientRepository.UpdateAddress(client.Address);

                    TempData["MSG_S"] = Message.MSG_S_001;
                    return RedirectToAction(nameof(Details), new { Id = _clientRepository.FindTheClientIdByAddress(client.Address.Id) });
                }
            }
            return View(nameof(Details), client);
        }
    }
}
