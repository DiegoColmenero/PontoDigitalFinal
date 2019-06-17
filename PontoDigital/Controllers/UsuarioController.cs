using PontoDigital.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PontoDigital.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_USUARIO = "_USUARIO";
        private const string SESSION_ADM = "_ADM";
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            var email = form["email"];
            var senha = form["senha"];
            var usuario = usuarioRepositorio.ObterPor(email);

                if (usuario != null && usuario.Senha.Equals(senha))
                {
                    HttpContext.Session.SetString(SESSION_EMAIL, email);
                    HttpContext.Session.SetString(SESSION_USUARIO, usuario.Nome);
                    System.Console.WriteLine("LOGOUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU\n\n\n\n\n\n\n\n");
                }
                
            return RedirectToAction("Index", "Home");    
        
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SESSION_EMAIL);
            HttpContext.Session.Remove(SESSION_USUARIO);
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}