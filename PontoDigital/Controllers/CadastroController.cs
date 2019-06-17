using System;
using PontoDigital.Models;
using PontoDigital.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PontoDigital.Controllers
{
    public class CadastroController: Controller
    {
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        public IActionResult Index()
        {
            
            ViewData["NomeView"] = "Cadastro";
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form){
            UsuarioModel usuario = new UsuarioModel();
            usuario.Nome = form["nome"];
            usuario.Email = form["email"];
            usuario.DataNascimento = DateTime.Parse(form["data"]);
            usuario.Senha = form["senha"];

            usuarioRepositorio.Inserir(usuario);
            ViewData["Action"] = "Usuario";
            
            return RedirectToAction("Index");
        }
    }
}