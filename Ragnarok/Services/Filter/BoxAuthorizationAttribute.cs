using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ragnarok.Services.Login;
using System;

namespace Ragnarok.Services.Filter
{
    public class BoxAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private OpenBox _openBox;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _openBox = (OpenBox)context.HttpContext.RequestServices.GetService(typeof(OpenBox));

            if (_openBox.GetSaleBox() == null)
            {
                context.Result = new RedirectToActionResult("Box", "Sales", new { Area = "Employee" }, "#ClosedBox");
            }
        }
    }
}
