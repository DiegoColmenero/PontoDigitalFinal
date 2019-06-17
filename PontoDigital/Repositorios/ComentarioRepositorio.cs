using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PontoDigital.Models;

namespace PontoDigital.Repositorios
{
    public class ComentarioRepositoiro : BaseRepositorio{
        public static uint CONT = 0;
        private const string PATH = "DataBase/Comentario.csv";
        private List<ComentarioModel> comentarios = new List<ComentarioModel> ();


        public bool Inserir (ComentarioModel comentario) {
            CONT++;
            if (!File.Exists(PATH)){
                comentario.Id = 1;
                File.Create(PATH).Close();
            }else{
                comentario.Id= File.ReadAllLines(PATH).Length + 1;
            }

            comentario.Aprovado = false;
            string linha = $"{comentario.Id};{comentario.Nome};{comentario.Texto};{comentario.Data};{comentario.Aprovado}\n";
            File.AppendAllText (PATH, linha);

            return true;
        }

        public ComentarioModel ObterPor (int id) {
            string[] linhas = File.ReadAllLines(PATH);
            
            foreach (var item in linhas){
                string[] dados = item.Split(";");

                if (id.ToString().Equals(dados[0])){
                    var comentario = new ComentarioModel();
                    comentario.Id = int.Parse(dados[0]);
                    comentario.Nome = dados[1];
                    comentario.Texto = dados[2];
                    comentario.Data = DateTime.Parse(dados[3]);
                    comentario.Aprovado = bool.Parse(dados[4]);

                    return comentario;
                }
            }
            return null;    
        }


        public List<ComentarioModel> ListarTodos () {
            List<ComentarioModel> listaDecomentarios = new List<ComentarioModel>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas){
                if (item != null){
                    string[] dados = item.Split(";");

                    var comentario = new ComentarioModel();
                    comentario.Id = int.Parse(dados[0]);
                    comentario.Nome = dados[1];
                    comentario.Texto = dados[2];
                    comentario.Data = DateTime.Parse(dados[3]);
                    comentario.Aprovado = bool.Parse(dados[4]);

                    listaDecomentarios.Add(comentario);
                }
            }
            return listaDecomentarios;
        }
        public void Deletar(ComentarioModel comentario){
            string[] linhas = File.ReadAllLines(PATH);
            List<string> linesList = File.ReadAllLines(PATH).ToList();
            

            for (int i = 0; i < linhas.Length; i++)
            {
                string[] linha = linhas[i].Split(";");

                if (comentario.Id.ToString() == linha[0]){

                    linesList.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(PATH,linesList.ToArray());

        }
         public void Editar(ComentarioModel comentario){
           string[] linhas = File.ReadAllLines(PATH);
                
            for (int i = 0; i < linhas.Length; i++)
            {
                string[] linha = linhas[i].Split(";");

                if (comentario.Id.ToString() == linha[0]){
                    linhas[i] = $"{comentario.Id};{comentario.Nome};{comentario.Texto};{comentario.Data.ToShortDateString()};{comentario.Aprovado}";
                    break;
                }
            }
            File.WriteAllLines(PATH,linhas); 
        }
        public List<ComentarioModel> ListarAprovados(){
            List<ComentarioModel> listaDeComentarios = new List<ComentarioModel>();

            string[] linhas = File.ReadAllLines(PATH);


            for (int i = linhas.Length; i > 0; i--){  
                
                if (linhas[i-1] != null){
                    string[] dados = linhas[i-1].Split(";");

                    if (bool.Parse(dados[4]))
                    {
                        var comentario = new ComentarioModel();
                        comentario.Id = int.Parse(dados[0]);
                        comentario.Nome = dados[1];
                        comentario.Texto = dados[2];
                        comentario.Data = DateTime.Parse(dados[3]);
                        comentario.Aprovado = bool.Parse(dados[4]);

                        listaDeComentarios.Add(comentario);
                    }
                    continue;   
                }
            }
            return listaDeComentarios;
        }
        public List<ComentarioModel> ListarReprovados(){
            List<ComentarioModel> listaDeComentarios = new List<ComentarioModel>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas){
                if (item != null){
                    string[] dados = item.Split(";");

                    if (!bool.Parse(dados[4]))
                    {
                        var comentario = new ComentarioModel();
                        comentario.Id = int.Parse(dados[0]);
                        comentario.Nome = dados[1];
                        comentario.Texto = dados[2];
                        comentario.Data = DateTime.Parse(dados[3]);
                        comentario.Aprovado = bool.Parse(dados[4]);

                        listaDeComentarios.Add(comentario);
                    }
                    continue;   
                }
            }
            return listaDeComentarios;
        }

    }
}