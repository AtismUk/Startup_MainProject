using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Startup_MainProject.Services.Model;
using Startup_MainProject.Services.ModelDto;
using Startup_MainProject.Services.Operation.IOperation;
using System.Security.Claims;

namespace Startup_MainProject.Controllers
{
    public class AdtController : Controller
    {
        ICrudOperation _crud;
        public AdtController(ICrudOperation crudOperation)
        {
            _crud = crudOperation;
        }
        public IActionResult Index()
        {
            var res = _crud.GetAllModel();
            return View("Index", res);
        }
    }
}
