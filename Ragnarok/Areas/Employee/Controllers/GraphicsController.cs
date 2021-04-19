using Microsoft.AspNetCore.Mvc;
using Ragnarok.Services.Graphics;
using Ragnarok.Services.Login;

namespace Ragnarok.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class GraphicsController : Controller
    {
        private readonly GraphicsGenerator _graphicsGenerator;
        private readonly EmployeeLogin _employeeLogin;

        public GraphicsController(GraphicsGenerator graphicsGenerator, EmployeeLogin employeeLogin)
        {
            _graphicsGenerator = graphicsGenerator;
            _employeeLogin = employeeLogin;
        }
        
        public IActionResult SalesSevenDays(string result)
        {
            var list = _graphicsGenerator.SalesForTheLastSevenDays(_employeeLogin.GetEmployee().BusinessId);
            return View();
        }
    }
}
