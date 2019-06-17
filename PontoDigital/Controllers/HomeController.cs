using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital.Models;

namespace PontoDigital.Controllers
{
    public class HomeController : Controller
    {
    
        [HttpGet]
        public IActionResult Index(){
            ViewData["LoginE"] = HttpContext.Session.GetString("_EMAIL");
            ViewData["LoginN"] = HttpContext.Session.GetString("_USUARIO");
            
            return View();
        }
        

    }
}