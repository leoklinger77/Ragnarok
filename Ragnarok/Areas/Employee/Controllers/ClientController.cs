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
        public IActionResult Insert(ClientJuridical juridical, ClientPhysical physical)
        {
            if (ModelState.IsValid)
            {

            }
            return Json("Error");
        }
    }
}
