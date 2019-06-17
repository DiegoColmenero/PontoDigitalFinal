using System.Collections.Generic;
using PontoDigital.Models;
using PontoDigital.Repositorios;

namespace PontoDigital.ViewModels
{
    public class AdministradorViewModel
    {
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        private ComentarioRepositoiro comentarioRepositorio = new ComentarioRepositoiro();
        public List<ComentarioModel> listaDeComentarios = new List<ComentarioModel>();
        public List<UsuarioModel> listaDeUsuarios = new List<UsuarioModel>();
        public List<ComentarioModel> listaDeReprovados = new List<ComentarioModel>();

        public UsuarioModel UsuarioRecuperado;
        public int QuantidadeDeComentarios;
        public int QuantidadeDeAprovados;
        public int QuantidadeDeReprovados;
        public int QuantidadeDeUsuarios;
        
        public AdministradorViewModel(){
            listaDeComentarios = comentarioRepositorio.ListarTodos(); 
            listaDeUsuarios = usuarioRepositorio.ListarTodos();    
            QuantidadeDeComentarios = listaDeComentarios.Count;

            QuantidadeDeUsuarios = listaDeUsuarios.Count;
            List<ComentarioModel> listaDeAprovados = new List<ComentarioModel>();
            listaDeAprovados = comentarioRepositorio.ListarAprovados();
            QuantidadeDeAprovados = listaDeAprovados.Count;
            
            listaDeReprovados = comentarioRepositorio.ListarReprovados();
            QuantidadeDeReprovados = listaDeReprovados.Count;
        }
    
        public AdministradorViewModel(UsuarioModel usuarioRecuperado){
            listaDeComentarios = comentarioRepositorio.ListarTodos(); 
            listaDeUsuarios = usuarioRepositorio.ListarTodos();    
            QuantidadeDeComentarios = listaDeComentarios.Count;

            QuantidadeDeUsuarios = listaDeUsuarios.Count;
            List<ComentarioModel> listaDeAprovados = new List<ComentarioModel>();
            listaDeAprovados = comentarioRepositorio.ListarAprovados();
            QuantidadeDeAprovados = listaDeAprovados.Count;
            
            listaDeReprovados = comentarioRepositorio.ListarReprovados();
            QuantidadeDeReprovados = listaDeReprovados.Count;

            this.UsuarioRecuperado = usuarioRecuperado;
        }            


    }
}