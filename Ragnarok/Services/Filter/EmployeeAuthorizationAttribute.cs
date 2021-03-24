using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ragnarok.Services.Login;
using System;

namespace Ragnarok.Services.Filter
{
    public class EmployeeAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private EmployeeLogin _employeeLogin;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _employeeLogin = (EmployeeLogin)context.HttpContext.RequestServices.GetService(typeof(EmployeeLogin));

            if (_employeeLogin.GetEmployee() == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { Area = "" });
            }
        }
    }
}
