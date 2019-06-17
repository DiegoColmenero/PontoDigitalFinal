using PontoDigital.Models;

namespace PontoDigital.Repositorios
{
    public class AdministradorRepositorio
    {
        ComentarioModel comentario = new ComentarioModel();
        public ComentarioModel Aprovado()
        {
            comentario.Aprovado = true;

            return comentario;

        }
        public ComentarioModel Negado(){
            comentario.Aprovado = false;
            
            return comentario;
        }
    }
}