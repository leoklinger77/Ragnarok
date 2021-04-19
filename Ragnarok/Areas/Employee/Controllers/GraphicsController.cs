using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models.ViewModels.Graphics;
using Ragnarok.Services.Filter;
using Ragnarok.Services.Graphics;
using Ragnarok.Services.Login;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Areas.Employee.Controllers
{
    [Area("Employee")]
    [EmployeeAuthorization]
    public class GraphicsController : Controller
    {
        private readonly GraphicsGenerator _graphicsGenerator;
        private readonly EmployeeLogin _employeeLogin;

        public GraphicsController(GraphicsGenerator graphicsGenerator, EmployeeLogin employeeLogin)
        {
            _graphicsGenerator = graphicsGenerator;
            _employeeLogin = employeeLogin;
        }
        [HttpPost]
        public async Task<IActionResult> SalesSevenDaysAsync()
        {
            try
            {
                ICollection<GraphicsStandard> list = await _graphicsGenerator.SalesForTheLastSevenDays(_employeeLogin.GetEmployee().BusinessId);
                return Json(list);
            }
            catch (Exception e)
            {

                return Json("Error: " + e.Message);
            }
            
        }
    }
}
