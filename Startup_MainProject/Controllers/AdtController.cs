using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Startup_MainProject.Services.ModelDto;
using Startup_MainProject.Services.Operation.IOperation;

namespace Startup_MainProject.Controllers
{
    public class AdtController : Controller
    {
        ICrudOperation _crud;
        public AdtController(ICrudOperation crudOperation)
        {
            _crud = crudOperation;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _crud.GetAllModel();
            return View(res);
        }
    }
}
