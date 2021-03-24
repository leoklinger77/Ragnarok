using Microsoft.AspNetCore.Mvc;
using Ragnarok.Services.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Areas.Employee.Controllers
{
    [Area("Employee")]
    [EmployeeAuthorization]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
