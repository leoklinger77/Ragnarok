using Microsoft.AspNetCore.Mvc;
using Ragnarok.Models.ViewModels;
using Ragnarok.Services.Filter;
using Ragnarok.Services.WebService;

namespace Ragnarok.Controllers
{
    [EmployeeAuthorization]
    public class ServiceController : Controller
    {
        private readonly WSCorreiosAPI _correiosAPI;

        public ServiceController(WSCorreiosAPI correiosAPI)
        {
            _correiosAPI = correiosAPI;
        }

        public IActionResult SearchByZipCode(string zipCode)
        {
            try
            {
                AddressWSCorreiosViewModel viewModel = _correiosAPI.SearchByZipCode(zipCode);
                return Json(viewModel);
            }
            catch
            {
                return Json("Cep inválido");
            }
            
        }
    }
}
