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
    }
}
