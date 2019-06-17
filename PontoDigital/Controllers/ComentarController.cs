using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PontoDigital.Models;
using System;
using PontoDigital.Repositorios;
using PontoDigital.ViewModels;

namespace PontoDigital.Controllers
{
    public class ComentarController :  Controller
    {
        private ComentarioRepositoiro comentarioRepositoiro = new ComentarioRepositoiro();
        ComentarioViewModel comentarioViewModel = new ComentarioViewModel();
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["LoginE"] = HttpContext.Session.GetString("_EMAIL");
            ViewData["LoginN"] = HttpContext.Session.GetString("_USUARIO");

            return View(comentarioViewModel);
        }
        public IActionResult Comentar(IFormCollection form){
            ComentarioModel comentario = new ComentarioModel();
            comentario.Nome = HttpContext.Session.GetString("_USUARIO");
            comentario.Texto = form["comentario"];
            comentario.Data = DateTime.Now;

            comentarioRepositoiro.Inserir(comentario);
            ViewData["Action"] = "Comentario";

            return RedirectToAction("ComentarioSucesso", "Comentar");

            

        }
        public IActionResult ComentarioSucesso()
        {
            ViewData["LoginE"] = HttpContext.Session.GetString("_EMAIL");
            ViewData["LoginN"] = HttpContext.Session.GetString("_USUARIO");
            return View();
        }
    }
}