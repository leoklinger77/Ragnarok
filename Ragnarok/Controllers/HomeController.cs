using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }      
        [HttpPost]
        public IActionResult Login(Employee employee)
        {
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }
    }
}
