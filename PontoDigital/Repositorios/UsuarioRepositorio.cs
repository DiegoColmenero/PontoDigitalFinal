using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using PontoDigital.Models;
using System.Text.RegularExpressions;
using System;

namespace PontoDigital.Repositorios {
    public class UsuarioRepositorio : BaseRepositorio {
        public static uint CONT = 0;
        private const string PATH = "DataBase/Usuario.csv";
        private List<UsuarioModel> usuarios = new List<UsuarioModel> ();

        public bool Inserir (UsuarioModel usuario) {
            CONT++;
            if (!File.Exists(PATH)){
                usuario.Id = 1;
                File.Create(PATH).Close();
            }else{
                usuario.Id= File.ReadAllLines(PATH).Length + 1;
            }

            usuario.Adm = false;
            string linha = $"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento.ToShortDateString()};{usuario.Adm}";
            File.AppendAllText (PATH, linha);

            return true;
        }

        public UsuarioModel ObterPor (int id) {
            string[] linhas = File.ReadAllLines(PATH);
            
            foreach (var item in linhas){
                string[] dados = item.Split(";");

                if (id.ToString().Equals(dados[0])){
                    var usuario = new UsuarioModel();
                    usuario.Id = int.Parse(dados[0]);
                    usuario.Nome = dados[1];
                    usuario.Email = dados[2];
                    usuario.Senha = dados[3];
                    usuario.DataNascimento = DateTime.Parse(dados[4]);
                    usuario.Adm = bool.Parse(dados[5]);

                    return usuario;
                }
            }
            return null;    
        }

        public UsuarioModel ObterPor (string email) {
            List<UsuarioModel> usuarios = ListarTodos();
            UsuarioModel usuario;

            foreach (var item in usuarios){
                if (item != null && item.Email.Equals(email)){
                    usuario = item;
                    return usuario;
                }else{
                    continue;
                }
            }
            return null;
        }

        public List<UsuarioModel> ListarTodos () {
            List<UsuarioModel> listaDeUsuarios = new List<UsuarioModel>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas){
                if (item != null){
                    string[] dados = item.Split(";");

                    var usuario = new UsuarioModel();
                    usuario.Id = int.Parse(dados[0]);
                    usuario.Nome = dados[1];
                    usuario.Email = dados[2];
                    usuario.Senha = dados[3];
                    usuario.DataNascimento = DateTime.Parse(dados[4]);
                    usuario.Adm = bool.Parse(dados[5]);

                    listaDeUsuarios.Add(usuario);
                }
            }
            return listaDeUsuarios;
        }

    }
}