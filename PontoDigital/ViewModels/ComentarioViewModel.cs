using System.Collections.Generic;
using PontoDigital.Models;
using PontoDigital.Repositorios;

namespace PontoDigital.ViewModels
{
    public class ComentarioViewModel
    {
        public List<ComentarioModel> listaDeComentarios = new List<ComentarioModel>();
        private ComentarioRepositoiro comentarioRepositorio = new ComentarioRepositoiro();
        public ComentarioViewModel(){
            listaDeComentarios = comentarioRepositorio.ListarAprovados();
        }
    }
}