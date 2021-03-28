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
    public class PositionNameController : Controller
    {
        private readonly IPositionNameRepository _positionNameRepository;
        private readonly EmployeeLogin _employeeLogin;

        public PositionNameController(IPositionNameRepository positionNameRepository, EmployeeLogin employeeLogin)
        {
            _positionNameRepository = positionNameRepository;
            _employeeLogin = employeeLogin;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ICollection<PositionName> list = _positionNameRepository.FindAlls(_employeeLogin.GetEmployee().BusinessId);
            return View(list);
        }        
        [HttpPost]
        public IActionResult Insert(PositionName positionName)
        {
            if (ModelState.IsValid)
            {
                positionName.InsertDate = DateTime.Now;
                positionName.BusinessId = _employeeLogin.GetEmployee().BusinessId;
                _positionNameRepository.Insert(positionName);
                TempData["MSG_S"] = Message.MSG_S_002;
                return Json("Ok");
            }
            return Json("Error");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            PositionName positionName = _positionNameRepository.FindById(id);
            return View(positionName);
        }
        [HttpPost]
        public IActionResult Update(PositionName positionName)
        {
            if (ModelState.IsValid)
            {
                positionName.UpdateDate = DateTime.Now;
                _positionNameRepository.Update(positionName);
                TempData["MSG_S"] = Message.MSG_S_001;
                return RedirectToAction(nameof(Details), new { id = positionName.Id });
            }
            return View(nameof(Details), positionName);
        }
    }
}
