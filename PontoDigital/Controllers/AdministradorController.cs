using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital.Models;
using PontoDigital.Repositorios;
using PontoDigital.ViewModels;


namespace PontoDigital.Controllers
{
    public class AdministradorController: Controller
    {
        public IActionResult Index(){
            ViewData["LoginN"] = HttpContext.Session.GetString("_NOME");
            ViewData["LoginE"] = HttpContext.Session.GetString("_EMAIL");
            
            
                
                    AdministradorViewModel administradorViewModel = new AdministradorViewModel();
                    
                    return View(administradorViewModel);
                
            
    
        }

        public IActionResult Comentarios(){
            ViewData["UserN"] = HttpContext.Session.GetString("USER_NOME");
            ViewData["UserE"] = HttpContext.Session.GetString("USER_EMAIL");
            ViewData["UserA"] = HttpContext.Session.GetString("USER_ADMIN");
            ViewData["Css"] = "Comentarios";
            
            if (ViewData["UserA"] != null)
            {
                if (bool.Parse((string)ViewData["UserA"]))
                {
                    AdministradorViewModel administradorViewModel = new AdministradorViewModel();
            
                    return View(administradorViewModel);
                }
            }
            return RedirectToAction("Index","Home");      
        }
        public IActionResult Usuarios(){
            ViewData["UserN"] = HttpContext.Session.GetString("USER_NOME");
            ViewData["UserE"] = HttpContext.Session.GetString("USER_EMAIL");
            ViewData["UserA"] = HttpContext.Session.GetString("USER_ADMIN");
            ViewData["Css"] = "Usuarios";
            
            
            if (ViewData["UserA"] != null)
            {
                if (bool.Parse((string)ViewData["UserA"]))
                {
                    AdministradorViewModel administradorViewModel = new AdministradorViewModel();
            
                    return View(administradorViewModel);
                }
            }
            return RedirectToAction("Index","Home");      
        }

        

        public IActionResult Aprovar(int id){
            


            System.Console.WriteLine(id);
            ComentarioRepositoiro comentarioRepositorio = new ComentarioRepositoiro();
            ComentarioModel comentario = comentarioRepositorio.ObterPor(id);
                
            if (comentario.Aprovado){
                comentario.Aprovado = false;
            }else{
                comentario.Aprovado = true;
            }

            comentarioRepositorio.Editar(comentario);

            return RedirectToAction("Comentarios");
        }
        public IActionResult Deletar(int id){
            System.Console.WriteLine(id);
            ComentarioRepositoiro comentarioRepositorio = new ComentarioRepositoiro();
            ComentarioModel comentario = comentarioRepositorio.ObterPor(id);

            comentarioRepositorio.Deletar(comentario);

            return RedirectToAction("Comentarios");
        }


        // public IActionResult Editar(int id){

        //     ViewData["UserN"] = HttpContext.Session.GetString("USER_NOME");
        //     ViewData["UserE"] = HttpContext.Session.GetString("USER_EMAIL");
        //     ViewData["UserA"] = HttpContext.Session.GetString("USER_ADMIN");
        //     ViewData["Css"] = "Editar";
            
            
        //     if (ViewData["UserA"] != null)
        //     {
        //         if (bool.Parse((string)ViewData["UserA"]))
        //         {
        //            ComentarioRepositoiro comentarioRepositorio = new ComentarioRepositoiro();
        //            ComentarioModel comentario = comentarioRepositorio.ObterPor(id);

        //             AdministradorViewModel administradorViewModel = new AdministradorViewModel(comentarioRecuperado);

        //             return View(administradorViewModel);
        //         }
        //     }
        //     return RedirectToAction("Index","Home");      
        // }

    }
}